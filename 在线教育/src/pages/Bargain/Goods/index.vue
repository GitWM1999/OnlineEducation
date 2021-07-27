
<template>

   <div style="width:100%">
    <div>
       <el-breadcrumb separator="/">
  <el-breadcrumb-item :to="{ path: '/' }">首页</el-breadcrumb-item>
  <el-breadcrumb-item><a href="/">活动管理</a></el-breadcrumb-item>
  <el-breadcrumb-item>活动列表</el-breadcrumb-item>
  <el-breadcrumb-item>活动详情</el-breadcrumb-item>
</el-breadcrumb>
    </div>
       <div>
         <el-form>
           <span>砍价状态:</span>
  <el-select v-model="Status" clearable placeholder="请选择">
    <el-option
      v-for="item in options"
      :key="item.value"
      :label="item.label"
      :value="item.value">
    </el-option>
  </el-select>
 
  <span>商品搜索</span>
    <el-input v-model="GoodsName" placeholder="商品名称、ID" style="width:200px"></el-input>
     <el-button icon="el-icon-search" circle @click="GetBargainData"></el-button>
       </el-form>
 <el-form>
       <el-button type="primary" @click="CutGoods()">添加砍价图片</el-button>
 </el-form>
        <el-table
      :data="tableData"
      style="width: 100%">
      <el-table-column
        prop="cutGoodsID"
        label="ID">
      </el-table-column>
      <el-table-column
        prop="cutImg"
        label="砍价图片">
        <template slot-scope="scope">
            <img :src="'http://10.3.181.32:53590'+scope.row.cutImg" style="width:80px;height:80px">
        </template>
      </el-table-column>
      <el-table-column
        prop="cutName"
        label="砍价名称">
      </el-table-column>
      <el-table-column
        prop="cutPrice"
        label="砍价价格">
      </el-table-column>
      <el-table-column
        prop="bargain_Amount"
        label="最低价">
      </el-table-column>
      <el-table-column
        prop="cutPeople"
        label="参与人数">
      </el-table-column>
      <el-table-column
        prop="cutPartici"
        label="帮忙砍价人数"
        >
      </el-table-column>
      <el-table-column
        prop="cutSuccess"
        label="砍价成功人数"
        >
      </el-table-column>
      <el-table-column
        prop="limited"
        label="限量">
      </el-table-column>
      <el-table-column
        prop="limitedResidue"
        label="限量剩余">
      </el-table-column>
      <el-table-column
        prop="endTimeStr"
        label="结束时间">
      </el-table-column>
      <el-table-column
        prop="cutState"
        label="砍价状态">
        <template slot-scope="scope">
          <el-switch v-model="scope.row.cutState" :active-value="1" :inactive-value="0">
          </el-switch>
      </template>
      </el-table-column>
      <el-table-column
        label="操作">
      <template slot-scope="scope2">
       <el-button type="primary" icon="el-icon-edit" circle @click="EditBackFill(scope2.row)"></el-button>
       <el-button type="danger" icon="el-icon-delete" circle @click="BargainDel(scope2.row)"></el-button>
    </template>
      </el-table-column>
    </el-table>
    <el-pagination
      @current-change="handlePageChange"
      @size-change="handleSizeChange"
      :current-page="currentpage"
      :page-size="size"
      background
      layout="prev,pager,next"
      :total="totalcount" >
    </el-pagination>
       </div>
     
  <el-dialog
    title="编辑"
    :visible.sync="dialogEidtVisible"
    width="50%"
    :before-close="handleEidtclose"
    >
    
    <el-form :v-model="CutFrom">
      <el-form-item label="砍价图片">
            <img :src="'http://10.3.181.32:53590'+ this.CutFrom.cutImg" width="100" height="100" />
          </el-form-item>
         <el-form-item label="砍价名称">
             <el-input v-model="CutFrom.cutName"></el-input>
          </el-form-item>
           <el-form-item label="砍价价格">
                  <el-input-number
                    v-model="CutFrom.cutPrice"
                    @change="handleChange"
                    :precision="2"
                    :step="1"
                  ></el-input-number>
          </el-form-item>
           <el-form-item label="最低价">
            <el-input v-model="CutFrom.bargain_Amount"></el-input>
          </el-form-item>
           <el-form-item label="参与人数">
            <el-input-number
              v-model="CutFrom.cutPartici"
              @change="handleChange"
              label="描述文字"
            ></el-input-number>
          </el-form-item>
           <el-form-item label="帮忙砍价人数">
             <el-input-number
              v-model="CutFrom.cutPeople"
              @change="handleChange"
              label="描述文字"
            ></el-input-number>
          </el-form-item>
           <el-form-item label="砍价成功人数">
             <el-input-number
              v-model="CutFrom.cutSuccess"
              @change="handleChange"
              label="描述文字"
            ></el-input-number>
          </el-form-item>
           <el-form-item label="限量">
            <el-input-number
              v-model="CutFrom.limited"
              @change="handleChange"
              label="描述文字"
            ></el-input-number>
          </el-form-item>
           <el-form-item label="限量剩余">
            <el-input-number
              v-model="CutFrom.limitedResidue"
              @change="handleChange"
              label="描述文字"
            ></el-input-number>
          </el-form-item>
           <el-form-item label="结束时间">
            <el-date-picker
            v-model="CutFrom.endTime"
            type="date"
            placeholder="选择日期">
           </el-date-picker>
          </el-form-item>
          <el-form-item label="砍价状态">
            <el-switch
            v-model="CutFrom.cutState"
            active-color="#13ce66"
            inactive-color="#ff4949"
            :active-value="1" :inactive-value="0">
            </el-switch>
          </el-form-item>
    </el-form>
    
     
    <span slot="footer" >
       <el-button type="primary" @click="EditBargain()">修改</el-button>
       <el-button @click="dialogVisible=false">取消</el-button>
    </span>
    </el-dialog>
   </div>
   
  </template>

<script>
export default {

      data() {
        return {
          tableData:[],
          options:[
            {
                value:'1',
                  label:'开启'
            },
            {
                  value:'0',
                  label:'关闭'
              }
          ],
          value:'',
          GoodsName:'',
          dialogVisible:false,
          active: 0,
          currentpage:1,
          size:4,
          totalcount:0,
          dialogEidtVisible:false,
          CutFrom:{
            cutGoodsID:0,
            cutImg:"",
            cutName:"",
            cutPrice:0,
            bargain_Amount:0,
            cutPartici:0,
            cutPeople:0,
            cutSuccess:0,
            limited:0,
            limitedResidue:0,
            endTime:"",
            cutState:0
          },
          Status:""
        }
      },
      created(){
         this.GetBargainData()
      },
      methods:{
         GetBargainData(){
             this.$axios({
                 url:"http://10.3.181.32:53590/api/Bargain/GetBargainData?currentpage="+this.currentpage+"&size="+this.size+"&GoodsName="+this.GoodsName+"&Status="+this.Status,
                 method:"get"
             }).then((res)=>{
                this.tableData= res.data.data;
                this.totalcount=res.data.totalcount;
             })
         },
         handleclose(){
          this.dialogVisible=false;
        },
        CutGoods(){
            this.$router.push("/main/bargain/goods/step");
        },
        handlePageChange(val){
           this.currentpage=val;
           this.GetBargainData();
        },
        handleSizeChange(val){
          this.size=val;
          this.GetBargainData();
        },
           BargainDel(row){
            this.$confirm('删除这条数据,是否继续?','提示',{
              confirmButtonText:'确定',
              cancelButtonText:'取消',
              type:'warning'
            }).then(()=>{
              this.$axios.post("http://10.3.181.32:53590/api/Bargain/BargainDel?id="+row.cutGoodsID).then(res=>{
                if(res.data=="1"){
                  this.$message({
                    type:'success',
                    message:'删除成功!'
                  });
                   window.location.reload();
                }
              })
            })
        },
        EditBackFill(row){
          this.CutFrom=row;
          this.dialogEidtVisible=true;
        },
        EditBargain(){
          this.$axios({
            url:"http://10.3.181.32:53590/api/Bargain/EditBargain",
            method:"post",
            params:this.CutFrom
          }).then(res=>{
            if(res.data>0){
              this.$message({
                message:'修改成功',
                type:'success'
              })
              window.location.reload();
              dialogEidtVisible=false;
            }
          })
        }
      }
      }
</script>

 