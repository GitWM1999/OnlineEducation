<template>
    <div>
        <span>选择商品</span>
        
        <el-button icon="el-icon-camera" circle @click="GoodsInfo()"></el-button>
        <img id="BackImg" :src="'http://10.3.181.32:53590'+this.img.toString()" alt="" 
         onerror="this.src='https://cube.elemecdn.com/6/94/4d3ea53c084bad6931a56d5158a48jpeg.jpeg'" style="width:80px;height:80px">
    <el-dialog
    title="商品列表"
   :visible.sync="dialogGoods"
   width="50%"
   :before-close="handleclose"
    >
  <el-table
    ref="multipleTable"
    :data="tableData"
    tooltip-effect="dark"
    style="width: 100%"
    @selection-change="handleSelectionChange">
    <el-table-column
      type="selection"
      width="55">
    </el-table-column>
    <el-table-column
      prop="goodsId"
      label="ID">
    </el-table-column>
     <el-table-column
      prop="goodsPicture"
      label="商品图">
      <template slot-scope="scope">
        <img :src="'http://10.3.181.32:53590'+scope.row.goodsPicture" style="width:80px;height:80px">
      </template>
    </el-table-column>
    <el-table-column
      prop="goodsName"
      label="商品名称">
    </el-table-column>
    <el-table-column
      prop="goodsOneName"
      label="商品分类">
    </el-table-column>
  </el-table>

    </el-dialog>
    
    </div>
    
</template>



<script>
  export default {
    data() {
      return {
     dialogGoods:false,
      tableData: [],
      multipleSelection: [],
      GoodsId:'',
      ids:[],
      img:[]
     
      };
    },
    methods: {
      GoodsInfo(){
      this.dialogGoods=true;
      this.ids=[];
      this.img=[];
      
       this.GetGoodsData();
      },
      handleclose(){
          this.dialogGoods=false;
        },
      handleSelectionChange(val) {
     
        this.multipleSelection = val;
       this.multipleSelection.forEach(item=>{
         this.ids.push(item.goodsId);
      
         this.img.push(item.goodsPicture);
         
       })
       if(this.ids.length==1){
         this.GoodsId=this.ids.toString();
         localStorage.setItem("GoodsId",this.GoodsId);
         this.handleclose();
         
       }else
       {
         this.ids=[];
         this.img=[];
       }

      },
      GetGoodsData(){
        this.$axios({
          url:"http://10.3.181.32:53590/api/Bargain/GetGoodsInfoData",
          method:"get"
        }).then((res)=>{
          this.tableData=res.data;
        
        })
      }
    }
  }
</script>