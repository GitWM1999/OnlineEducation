<template>
  <div style="width:1400px">
    <!-- 查询 -->
      <el-form :inline="true" :model="formInline" class="demo-form-inline">
        <div>
          <template>
            <el-select v-model="GetValue" placeholder="请选择">
              <el-option
                v-for="item in cities"
                :key="item.value"
                :label="item.label"
                :value="item.value">
                <span style="float: left">{{ item.label }}</span>
              </el-option>
            </el-select>
          </template>
          <el-form-item label="关键词">
            <el-input v-model="GetName" placeholder="请输入"></el-input>
          </el-form-item>
          <el-form-item>
            <el-button type="primary" icon="el-icon-search" @click="getDate()">搜索</el-button>
            <el-button type="success" icon="el-icon-share" @click="AddSecd()" circle>添加二级</el-button>
          </el-form-item>
        </div>
      </el-form>
    <!-- 类型的显示 -->
    <el-table :data="tableData.slice((currentPage-1)*pagesize,currentPage*pagesize)">
        <el-table-column  prop="SecondType_Id" label="标号" width="80"></el-table-column>
        <el-table-column  prop="SecondType_Name" label="课程分类" width="90"></el-table-column>
        <el-table-column label="状态" align="center">
          <template slot-scope="scope"> 
           <el-switch
              v-model="scope.row.SecondType_State" 
              active-color="#13ce66"
              inactive-color="#DCDFE6"
              :active-value="1" 
              :inactive-value="0" 
              active-text="正常"
              inactive-text="异常"
              >
            </el-switch>
          </template>
          </el-table-column>    
        <el-table-column  prop="SecondType_Sort" label="排序" width="80"></el-table-column>
        <el-table-column  prop="SecondType_Remark" label="备注" width="300"></el-table-column>
        <el-table-column label="操作">
          <template slot-scope="scope">

            <el-button
              size="mini"
              type="primary"
              plain
              icon="el-icon-edit"
              @click="Enittype(scope.row.SecondType_Name,scope.row.SecondType_Id)"
            >编辑</el-button>

            <el-button
              type="primary"
              icon="el-icon-edit"
              size="mini"
              @click="Remove(scope.row.SecondType_Id)"
            >删除</el-button>
          </template>
        </el-table-column>
    </el-table>  
 <!-- 二级类型的添加 -->
<el-dialog
  title="提示"
  :visible.sync="TowDialog"
  width="30%"
  :before-close="handleClose">
      <el-form :inline="true" :model="formInline" class="demo-form-inline">
        <div>
          <el-form-item label="关键词">
            <el-input v-model="TwoName" placeholder="请输入"></el-input>
          </el-form-item>
          <el-form-item>
            <el-button type="primary" icon="el-icon-search" @click="QuickLook()">添加二级</el-button>
          </el-form-item>
        </div>
      </el-form>         
</el-dialog>
<!-- 一级类型的修改 -->
<el-dialog
  title="提示"
  :visible.sync="UptDialog"
  width="30%"
  :before-close="handleClose">
      <el-form :inline="true" :model="formInline" class="demo-form-inline">
        <div>
          <el-form-item label="关键词">
            <el-input v-model="UptName" placeholder="请输入"></el-input>
          </el-form-item>
          <el-form-item>
            <el-button type="primary" icon="el-icon-search" @click="UptClass()">修改</el-button>
          </el-form-item>
        </div>
      </el-form>         
</el-dialog>
    <!-- 分页 -->
    <div class="block">
        <el-pagination
          @size-change="handleSizeChange"
          @current-change="handleCurrentChange"
          :current-page="currentPage"
          :page-sizes="[1, 3, 5, 10]"
          :page-size="pagesize"
          layout="total, sizes, prev, pager, next, jumper"
          :total="tableData.length"
        ></el-pagination>
    </div>
</div>  
</template>

<script>
export default {

  data() {
    return {
      tableData:[],
      fatherId:"",
      TwoName:"",
      UptName:"",
      UptId:"",
      GetValue:"",
      OneClass:"",
      OneName:"",
      GetName :"",
      OneDialog:false,
      TowDialog:false,
      UptDialog:false,
      id:"",
       cities: 
       [{
          value: '0',
          label: '异常'
        }, {
          value: '1',
          label: '正常'
        }],
       //分页
      currentPage: 1, //初始页
      pagesize: 3,    //每页的数据
    };
  },

   //初次加载函数
  created() {
    //接收路由的Id
    this.id = this.$route.query.Id
    this.getDate();

  },

  methods: {
    //显示
    getDate() {
      this.$axios
      ({
        url: "GetSedData",
          params: {
          Id:this.id,
          State: Number(this.GetValue),
          Name: this.GetName,
        },
        methods: "get",
      }).then((res) => {
        this.tableData = res.data.Data;
        console.log(res.data.Data)
      });
    },

    // 初始页currentPage、初始每页数据数pagesize和数据data
    handleSizeChange: function (size) {
      this.pagesize = size;
      console.log(this.pagesize); //每页下拉显示数据
    },

    //分页
    handleCurrentChange: function (currentPage) {
      this.currentPage = currentPage;
      console.log(this.currentPage); //点击第几页
    },


    //二级添加功能
    QuickLook() {
     this.$axios
      ({
        url: "AddSedStairData",
          params: {
          Name: JSON.stringify(this.TwoName),
          Id:this.fatherId
        },
        methods: "get",
      }).then((res) => {
        if(res.data.Data==200)
        {
          alert("添加成功!!");
        }
        this.getDate();
      });
    },

    //二级弹框 接收父级ID
    AddSecd(Id){
      this.fatherId=Id;
      this.TowDialog=true;
    },

    //反填
    Enittype(Name,Id) {
     this.UptName=Name;
     this.UptId=Id;
     this.UptDialog=true;
    },

    //修改
    UptClass()
    {
      this.$axios
      ({
        url: "UptStairData",
          params: {
          Name: this.UptName,
          Id:this.UptId
        },
        method: "put",
      }).then((res) => {
        this.tableData = res.data.Data;
        if(res.data.Code==200)
        {
          alert("修改成功!!");
          this.getDate();
        }
      });
    },


    //删除
    Remove(rowId)  
    {
      this.$confirm(`确认是否删除一级的分类吗?？`, "删除", {
        confirmButtonText: "确定",
      }).then(() => {
        //获取到要删除的id
        this.$axios({
          url: `DeleteSedType?Id=${rowId}`,
          methods: "DELETE",
        }).then((res) => {
          if (res.data.Code == 200) {
            alert("删除成功!");
            this.getDate(); //删除后刷新列表显示
          } else {
            alert("删除失败! 有子集存在!");
            return;
          }
          this.getDate(); //删除后刷新列表显示
        });
      });
    },
  },
};
</script>

