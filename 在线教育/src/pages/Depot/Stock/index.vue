<template>
    <div style="width:100%">

        
       <div class="hello">
    <el-form>
        <el-button type="primary" round @click="DepotAdd()">添加</el-button>
    </el-form>
    <el-form
      :model="basicInfo"
      size="mini"
    >

         <el-input v-model="DepotName" placeholder="请输入仓库名称" style="width:200px"></el-input>
      <el-input v-model="Serial" placeholder="请输入单号" style="width:200px"></el-input>
        <!--开始时间-->
        <span>开始时间：</span>
            <el-date-picker
              v-model="basicInfo.startDate"
              type="date"
              :picker-options="pickerOptionsStart"
              format="yyyy-MM-dd"
              value-format="yyyy-MM-dd HH:mm:ss"
              placeholder="选择开始时间"
            >
            </el-date-picker>
              <!--结束时间-->
      <span>结束时间：</span>
            <el-date-picker
              v-model="basicInfo.endDate"
              type="date"
              :picker-options="pickerOptionsEnd"
              format="yyyy-MM-dd"
              value-format="yyyy-MM-dd HH:mm:ss"
              placeholder="选择结束时间"
            >
            </el-date-picker>
      <el-button type="primary" plain @click="query()">查询</el-button>
   

    </el-form>
  
  </div>
    
  <el-table
    :data="tableData"
    border
    style="width: 100%">
    
    <el-table-column
      prop="stockSerial"
      label="入库单号">
    </el-table-column>
    <el-table-column
      prop="goodsPicture"
      label="图片"
      align="center"
      width="150">
          <template slot-scope="scope">
              <img :src="'http://10.3.181.32:53590'+scope.row.goodsPicture" style="width:50px;height:50px"  >
          </template>
    </el-table-column>
    <el-table-column
      prop="goodsName"
      label="商品名称">
    </el-table-column>
    <el-table-column
      prop="specification"
      label="商品规格">
    </el-table-column>
    <el-table-column
      prop="goodsSerial"
      label="商品编号">
    </el-table-column>
    <el-table-column
      prop="depoName"
      label="仓库名称">
    </el-table-column>
    <el-table-column
      prop="goodsStock"
      label="数量">
    </el-table-column>
    <el-table-column
      prop="stockTimeStr"
      label="入库时间">
    </el-table-column>
  </el-table>
   <el-dialog
   title="新增"
   :visible.sync="dialogVisible"
   width="50%"
   :before-close="handleclose"
   >
<el-form>
        <el-select v-model="value" clearable placeholder="请选择">
    <el-option
      v-for="item in options"
      :key="item.value"
      :label="item.depoName"
      :value="item.depotID">
    </el-option>
  </el-select>
    </el-form>
  <el-table
    ref="multipleTable"
    :data="GoodsInfo"
    tooltip-effect="dark"
    style="width: 100%"
    @selection-change="handleSelectionChange">
    <el-table-column
      type="selection"
      width="55">
    </el-table-column>
    <el-table-column
      prop="goodsSerial"
      label="商品编号"
      >
    </el-table-column>
    <el-table-column
      prop="goodsName"
      label="商品名称"
      >
    </el-table-column>
    <el-table-column
      prop="goodsPicture"
      label="商品图片"
      >
      <template slot-scope="scope">
              <img :src="'http://10.3.181.32:53590'+scope.row.goodsPicture" style="width:50px;height:50px"  >
          </template>
    </el-table-column>
    <el-table-column
      prop="goodsStock"
      label="商品库存"
      >
    </el-table-column>
    <el-table-column
      prop="specification"
      label="商品规格"
      >
    </el-table-column>
  </el-table>
  <div style="margin-top: 20px">
    <el-button @click="AddGoods()">添加</el-button>
    <el-button @click="toggleSelection()">取消选择</el-button>
  </div>

   </el-dialog>
   
    </div>
</template>

<script>
  export default {
    data() {
      return {
        tableData: [],
        GoodsInfo:[],
        DepotName:'',
        Serial:'',
         basicInfo: {
        // 创建时间 此时间可以通过后端接口取服务器时间 或者 用 new Date().getTime()
        createDate: new Date().getTime(),
        startDate: '', // 开始时间
        endDate: '' // 结束时间
    
     
      },
         dialogVisible:false,
         value:'',
         // 结束时间限制
       pickerOptionsEnd: {
        disabledDate: (time) => {
          if (this.basicInfo.startDate) {
            return time.getTime() < new Date(this.basicInfo.startDate).getTime();
          }
          return time.getTime() <= new Date(this.basicInfo.createDate).getTime() - 86400000;
        },
      }
      }
      
    },
    created(){
        this.GetList();
        this.Bind();
    },
    methods:{
      //获取入库数据
        GetList(depotname,serial,startDate,endDate){
            this.$axios({
                url:"http://10.3.181.32:53590/api/Stock/GetStockData?depotname="+depotname+"&serial="+serial+"&startDate="+startDate+"&endDate="+endDate,
                method:"get"
            }).then((res)=>{
                this.tableData=res.data;
            })
        },
        //获取商品数据
        GetDepotData(){
          this.$axios({
            url:"http://10.3.181.32:53590/api/Stock/GetGoodData",
            method:"get"
          }).then((res)=>{
            this.GoodsInfo=res.data;
          })
        },
        //查询
        query(){
           this.GetList(this.DepotName,this.Serial,this.basicInfo.startDate,this.basicInfo.endDate)
        },
        //打开添加
        DepotAdd(){
           this.dialogVisible=true;
           this.GetDepotData();
        },
        //关闭添加
        handleclose(){
          this.dialogVisible=false;
        },
        //选中行的数据
        handleSelectionChange(val) {
        this.multipleSelection = val;
        },
        //绑定
         Bind(){
              this.$axios.get("http://10.3.181.32:53590/api/Stock/DepotBind").then(res=>{
                  this.options=res.data;
              })
          },
          //商品添加到仓库
          AddGoods(){
               var ids=[];
               this.multipleSelection.forEach(item => {
                 ids.push(item.goodsId);
               });
               this.$axios({
                 url:"http://10.3.181.32:53590/api/Stock/StockAdd?GoodsIds="+ids+"&DepotId="+this.value,
                 method:"post"
               }).then((res)=>{
                 if(res.data>0){
                   this.$message({
                     message:"添加成功",
                     type:"success"
                   }) 
                   this.dialogVisible=false;
                   window.location.reload();
                 }
               })
               
          }

    }
  }
</script>