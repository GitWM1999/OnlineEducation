<template>
    <div>
          <el-container>
            <el-main>
      <el-form :inline="true" :model="formInline" class="demo-form-inline">
        <el-form-item label="商品搜索">
            <el-input v-model="searName" placeholder="商品"></el-input>
        </el-form-item>
        <el-form-item label="商品分类">
            <el-select v-model="formInline.type" placeholder="请选择">
            <el-option label="食品" value="shanghai"></el-option>
            <el-option label="服饰" value="beijing"></el-option>
            </el-select>
        </el-form-item>
        <el-form-item label="商品状态">
            <el-select v-model="formInline.region" placeholder="订单状态">
            <el-option label="未选定" value=" "></el-option>
            </el-select>
        </el-form-item>
        <el-form-item>
            <el-button type="primary" icon="el-icon-search" @click="onSubmit()">搜索</el-button>
             <el-button type="primary" icon="el-icon-plus" @click="AddGoods()">添加商品</el-button>
        </el-form-item>
        </el-form>
            <el-table :data="tableData">
                <el-table-column prop="id" label="商品日期" width="140">
                </el-table-column>
                <el-table-column prop="name" label="商品名称" width="120">
                </el-table-column>
                <el-table-column prop="age" label="商品数量">
                </el-table-column>
                <!-- <el-table-column prop="pImg" label="图片">
                  <template slot-scope= "scope">
                     <img :src="scope.row.pImg" style= "width: 36px;height:36px">
               </template>
                </el-table-column>
                <el-table-column prop="pState" label="状态" :formatter="formatBoolean">
                </el-table-column> -->
                <el-table-column label="操作">
            <template slot-scope="scope">
                <el-button
                size="mini"
                @click="handleEdit(scope.row)">编辑</el-button>
                <el-button
                size="mini"
                type="danger"
                @click="handleDelete(scope.row)">删除</el-button>
            </template>
            </el-table-column>
            </el-table>
                    <el-dialog
                      title="编辑商品信息"
                      :visible.sync="dialogVisible"
                      width="30%"
                      :before-close="handleClose">
                      <el-form ref="form" :model="form" label-width="80px">
                            <el-form-item label="商品名称">
                              <el-input v-model="form.Name"></el-input>
                            </el-form-item>
                             <!-- <el-form-item label="日期">
                              <el-col :span="11">
                                <el-date-picker type="date" placeholder="选择日期" v-model="form.date1" style="width: 100%;"></el-date-picker>
                              </el-col>
                              <el-col class="line" :span="2">-</el-col>
                              <el-col :span="11">
                                <el-time-picker placeholder="选择时间" v-model="form.date2" style="width: 100%;"></el-time-picker>
                              </el-col>
                            </el-form-item> -->
                            <el-form-item label="销量">
                              <el-input v-model="form.Age"></el-input>
                            </el-form-item>
                            <!-- <el-form-item label="库存">
                              <el-input v-model="form.Num"></el-input>
                            </el-form-item>
                            <el-form-item label="状态">
                              <el-switch v-model="form.Status"></el-switch>
                            </el-form-item> -->
                      </el-form>
                      <span slot="footer" class="dialog-footer">
                        <el-button @click="dialogVisible = false">取 消</el-button>
                        <el-button type="primary" @click="HandlerAdd()">确 定</el-button>
                      </span>
                    </el-dialog>
                <el-pagination
                
                
                :current-page="currentpage"
                :page-sizes="[2, 4, 6, 8]"
                :page-size="size"
                layout="total, sizes, prev, pager, next"
                :total="total">
                </el-pagination>
            </el-main>
        </el-container>
        
    </div>
</template>
<script>
  export default {
    data() {
      
      return {
        form: {
          Name:"",
          Age:0
          },
        formInline: {
   
          type: ''
        },
        //查询的
        searName: '',
        tableData: [],
        currentpage:1,
        size:2,
        total:10,
        
        dialogVisible: false
      }    
    },
    created()
    {       
        this.getList()
    },
    methods: {  
      handlePageChange(val){
        console.log(val);
        this.currentpage=val;
        this.getList()
      }, 
       getList(){
         this.$axios.get("http://10.3.181.32:53590/api/Test/GetData").then(res=>
         {
           console.log(res);
           alert(JSON.stringify(res.data));
           this.tableData=res.data;
           this.total=res.data.total;
         })
       },
      handleOpen(key, keyPath) {
        console.log(key, keyPath);
      },
      handleClose(key, keyPath) {
        console.log(key, keyPath);
      },
      //查询方法
      onSubmit()
      {
        this.getList();

      },
       formatBoolean: function (row, column, cellValue) {
            var ret = ''  //你想在页面展示的值
            if (cellValue) {
                ret = "已发货"  //根据自己的需求设定
            } else {
                ret = "未发货"
            }
            return ret;
        },
      //删除方法
      handleDelete(row) {
        alert(JSON.stringify(row.id) );
       this.$confirm('删除这条数据, 是否继续?', '提示', {
         confirmButtonText: '确定',
         cancelButtonText: '取消',
         type: 'warning'
       }).then(() => {
         this.$axios.post("http://10.3.181.32:53590/api/Test/DelData?id="+row.id+"").then(res=>
         {
           console.log(res);
           if(res.data=="1"){
               this.$message({
                type: 'success',
                message: '删除成功!'
              });
              //刷新
              window.location.reload();
           }else
           {
                this.$.$message.error("删除失败");
           }

         });
         
       }).catch(()=>{
         this.$message({
           type:'info',
           message:'已取消删除'
         })
       })
     },
     //打开对话框 
     handleEdit(){
       this.dialogVisible=true;

     },
     //修改操作
     HandlerAdd(){
       if(this.form.pId==undefined){
         alert(JSON.stringify(this.form) );
         this.$axios({
           url:"http://10.3.181.32:53590/api/Test/DataAdd",
           method:"post",
           params:this.form
           
         }).then((res)=>{
           if(res.data>0){
             this.$message({
               message:"添加成功",
               type:"success"
             })
           }
           window.location.reload();
           this.dialogVisible=false;
         })
       }
     },
     //关闭对话框
      handleClose() {
      this.dialogVisible = false;

       },
       //添加页面
       AddGoods(){
          this.dialogVisible = true;
        
       },
     
    }  
  };

</script>