<template>
  
  <div style="width:100%">
  <el-breadcrumb separator="/">
  <el-breadcrumb-item :to="{ path: '/' }">平台配置</el-breadcrumb-item>
  <el-breadcrumb-item>头部导航</el-breadcrumb-item>
  </el-breadcrumb>
  <el-form>
      <span>导航标题:</span>
      <el-input v-model="NavigationName"  style="width:200px"></el-input>

      <span>状态</span>
      <el-select v-model="value" clearable placeholder="请选择">
    <el-option
      v-for="item in options"
      :key="item.value"
      :label="item.label"
      :value="item.value">
    </el-option>
  </el-select>
  <el-button type="primary" @click="GetList()">查询</el-button>
  <el-button type="primary" @click="Add()">添加</el-button>
  </el-form>
  <el-table
      :data="tableData">
      <el-table-column
        prop="navigationId"
        label="序号">
      </el-table-column>
      <el-table-column
        prop="navigationName"
        label="导航标题">
      </el-table-column>
      <el-table-column
        prop="openMode"
        label="跳转方式">
        <template slot-scope="scope">
            <span v-if="scope.row.openMode==1" >
                新窗口打开
            </span>
            <span v-else>
                 同窗口打开
            </span>
        </template>
      </el-table-column>
      <el-table-column
        prop="orderBy"
        label="排序">
      </el-table-column>
      <el-table-column
        prop="status"
        label="状态">
        <template slot-scope="scope">
          <el-switch v-model="scope.row.status" :active-value="1" :inactive-value="0">
          </el-switch>
      </template>
      </el-table-column>
        

      <el-table-column label="操作">
           <template slot-scope="scope">
             <el-button type="primary" icon="el-icon-edit" circle @click="BackFill(scope.row)"></el-button>
       <el-button type="danger" icon="el-icon-delete" circle @click="DepotDel(scope.row)"></el-button>
           </template>
      </el-table-column>
      
    </el-table>
     <el-dialog
    title="编辑"
    :visible.sync="dialogVisible"
    width="50%"
    :before-close="handleclose"
    >
    <el-form :model="Navigation">
    <el-form-item label="导航标题">
      <el-input v-model="Navigation.NavigationId"></el-input>
    </el-form-item>
    <el-form-item label="打开方式">
       <el-radio v-model="Navigation.OpenMode" label="1">新窗口打开</el-radio>
       <el-radio v-model="Navigation.OpenMode" label="0">同窗口打开</el-radio>
    </el-form-item>
    <el-form-item label="排序">
      <el-input v-model="Navigation.OrderBy"></el-input>
    </el-form-item>
    <el-form-item label="状态">
      <el-radio v-model="Navigation.Status" label="1">正常</el-radio>
       <el-radio v-model="Navigation.Status" label="0">禁用</el-radio>
    </el-form-item>
    <span slot="footer" >
       <el-button type="primary" @click="NavigationAdd()">添加</el-button>
       <el-button @click="dialogVisible=false">取消</el-button>
    </span>
    </el-form>
    </el-dialog>
  </div>
  
</template>
<script>

export default({
    data(){
        return{
          tableData:[],
          NavigationName:"",
         options: [{
          value: '1',
          label: '开启'
        }, 
        {
          value: '0',
          label: '关闭'
        }],
        value: '',
         Navigation:{
             NavigationId:0,
             NavigationName:"",
             OpenMode:0,
             Status:0,
             OrderBy:0
         },
         dialogVisible:false
        }
    },
    created(){
        this.GetList();
    },
    methods:{
        GetList(){
            this.$axios({
                url:"/api/Navigation/GetNavigationData?navigationName="+this.NavigationName+"&status="+this.value,
                method:"get"
            }).then(res=>{
               alert(JSON.stringify(res.data));
                this.tableData=res.data;
            })
        },
        NavigationAdd(){
             
        },
        Add(){
          dialogVisible=true;
        }

    }
})
</script>
