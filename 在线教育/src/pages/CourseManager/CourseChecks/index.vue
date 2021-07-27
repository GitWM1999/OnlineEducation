<template>
<div>
    <el-container>
        <el-main>
    课程名称：<el-input v-model="courseName" placeholder="请输入名称" class="name">
    </el-input>
    状态：<el-select v-model="State" size="mini" clearable  style="width:140px" placeholder="请选择">
    <el-option
      v-for="item in options"
      :key="item.value"
      :label="item.label"
      :value="item.value">
    </el-option>
  </el-select>
  是否免费：<el-select v-model="free" size="mini" clearable style="width:140px"  placeholder="请选择">
    <el-option
      v-for="item in Freeoptions"
      :key="item.value"
      :label="item.label"
      :value="item.value">
    </el-option>
  </el-select>
  上下架：<el-select v-model="Checks" size="mini" clearable style="width:140px"  placeholder="请选择">
    <el-option
      v-for="item in Checkoptions"
      :key="item.value"
      :label="item.label"
      :value="item.value">
    </el-option>
  </el-select>
  审核状态：<el-select v-model="CheckState" size="mini" clearable style="width:140px"  placeholder="请选择">
    <el-option
      v-for="item in CheckStateoptions"
      :key="item.value"
      :label="item.label"
      :value="item.value">
    </el-option>
  </el-select>

  <el-button type="primary" @click="search()">查询</el-button>
   <!-- 显示 -->
    <el-table
    :data="tableData"
    border
    style="width: 100%;margin-top:15px">

    <el-table-column prop="Class_Id" label="序号" width="120">
    </el-table-column>

    <el-table-column
            prop="Class_Img"
            label="图片"
            align="center"
            width="150"
            ><template slot-scope="scope">
              <img :src="'http://10.3.181.28:58189' + scope.row.Class_Img"
                 style="width: 80px; height: 80px"/>
            </template>
          </el-table-column>

    <el-table-column prop="Class_Name" label="课程名称" width="120">
    </el-table-column>

    <el-table-column prop="TypeName" label="课程分类" width="125">
    </el-table-column>

    <el-table-column prop="Class_Price" label="价格" width="120">
    </el-table-column>

    <el-table-column prop="Class_Added" label="上下架" width="150">
         <template slot-scope="scope">
              <el-switch
                :value="scope.row.Class_Added == 1 ? true : false"
                @change="changePutaway(scope.row)"
                active-text="上架"
                inactive-text="下架" 
              >
              </el-switch>
            </template>
    </el-table-column>

    <el-table-column prop="Class_State" label="状态" width="150">
         <template slot-scope="scope">
              <el-switch
                :value="scope.row.Class_State == 1 ? true : false"
                @change="changeState(scope.row)"
                active-text="正常"
                inactive-text="禁用" 
              >
              </el-switch>
            </template>
    </el-table-column>

    <el-table-column prop="Class_Sort" label="排序" width="120">
    </el-table-column>

    <el-table-column prop="Class_CheckState" label="审核状态" width="120">
    </el-table-column>

    <el-table-column fixed="right" label="操作" width="120">
        <template slot-scope="scope">
            <el-button type="text" size="small" @click="Compile(scope.row)">编辑</el-button>
            <el-button type="text" size="small" v-if="scope.row.Class_CheckState==='审核未通过'" @click="checkAudit(scope.row)">审核</el-button>
        </template>
    </el-table-column>

  </el-table>

  <!-- 编辑 -->
    <el-dialog 
        title="编辑"
        :visible.sync="dialogVisible"
        >
        <el-form ref="form" :model="form" label-width="80px">
            <el-form-item label="课程名称">
                <el-input v-model="form.Class_Name" style="width:200px"></el-input>
            </el-form-item>

            <el-form-item label="是否收费">
              <el-radio-group v-model="form.Class_Price" >
                 <el-radio v-model="form.Class_Price" label="">收费</el-radio>
                 <el-radio v-model="form.Class_Price">免费</el-radio>
              </el-radio-group>
            </el-form-item>

            <el-form-item  v-if="form.Class_Price!='免费'"  label="收费">
                 <el-input v-model="form.Class_Price"  style="width:200px"></el-input>
            </el-form-item>

            <el-form-item label="文章描述">
                <div style="margin-bottom:110px">
                      <quill-editor ref="text" v-model="form.Class_ArticleDescription" class="myQuillEditor"  style="height:200px" />
                </div>
            </el-form-item>
        </el-form>

        <div style="margin-left:200px">
            <el-button type="primary" @click="sure()">确定</el-button>
            <el-button type="primary" @click="cancel()">取消</el-button>
        </div>
    </el-dialog>
    <!-- 审核 -->
    <el-dialog
         title="审核" width="25%"
        :visible.sync="dialogCheck">
          <el-form ref="formCheck" :model="formCheck">
              <el-form-item label="审核状态">
                  <template>
                  <el-radio v-model="formCheck.Class_CheckState" label="1">通过</el-radio>
                  <el-radio v-model="formCheck.Class_CheckState" label="2">不通过</el-radio>
                </template>
              </el-form-item>

              <el-form-item label="备注">
                  <el-input  type="textarea" :rows="4" v-model="formCheck.Class_CheckRemark" style="width:210px"></el-input>
              </el-form-item>
          </el-form>
          <div>
            <el-button type="primary" @click="ok()">确定</el-button>
            <el-button type="primary" @click="over()">取消</el-button>
        </div>
    </el-dialog>

    </el-main>
  </el-container>
</div>
</template>

<script>
export default {
    data(){
        return{
            courseName:'',
            tableData:[],
            value:true,
            stat:true,
            State:'',
            Checks:'',
            free:'',
            CheckState:'',
            dialogVisible:false,
            dialogCheck:false,
            
            options:[
                {
                    value:1,
                    label:'正常'
                },
                {
                    value:2,
                    label:'禁用'
                }
            ],
            Checkoptions:[
                {
                    value:1,
                    label:'上架'
                },
                {
                    value:2,
                    label:'下架'
                }
            ],
            Freeoptions:[
                {
                    value:1,
                    label:'是'
                },
                {
                    value:2,
                    label:'否'
                }
            ],
            CheckStateoptions:[
                {
                    value:"1",
                    label:'通过'
                },
                {
                    value:"2",
                    label:'不通过'
                }
            ],
            form:{
                Class_Id:0,
                Class_Name:'',
                Class_Price:0,
                Class_ArticleDescription:''
                
            },
            formCheck:{
              Class_Id:0,
              Class_CheckState:'',
              Class_CheckRemark:''
            }
        }
    },
    created(){
        this.GetCourse();
    },
    methods:{
        //显示
        GetCourse(){
            var states=0;
            var putaway=0;
            var freemoney='';
            if(this.State==''){
                states=0;
            }else{
                states=this.State;
            }

            if(this.Checks==''){
                putaway=0;
            }else{
                putaway=this.Checks;
            }
            
            if(this.free==1){
                freemoney="是";
            }
            if(this.free==2){
                freemoney="否";
            }


           this.$axios({url:
          "/api/GetCourse?courseName="+this.courseName+"&state="+states+"&check="+putaway+"&free="+freemoney+"&checkstat="+this.CheckState,
        method: "get", //请求方式
      }).then((res) => {
        console.log(res.data.Data); //在控制台查看数据
        this.tableData = res.data.Data; //把数据赋值给表单
        //this.totalcount = res.data.totalCount;
      });
      },
      //查询
      search(){
          this.GetCourse();
      },
      //修改上下架状态
      changePutaway(row){
          this.$axios
        .put("/api/EditClassStat?id=" + row.Class_Id + "&stat=" + row.Class_Added)
        .then((res) => {
          if (res.data.Data == 1) {
            if (row.Class_Added == 1) {
              row.Class_Added = 2;
            } else {
              row.Class_Added = 1;
            }           
          }
          if (res.data.Data == 0) {
            this.$message.error("修改失败");
          }
        });
      },
      //编辑
      Compile(row){
          this.dialogVisible=true;
          if(row!=null){
              this.form=row;
          }
      },
      //审核状态
      checkAudit(row){
         this.dialogCheck=true;
         if(row!=null){
           this.formCheck=row;
         }
      },
      //修改状态
      changeState(row){
           this.$axios
        .put("/api/EditCourseStat?id=" + row.Class_Id + "&classStat=" + row.Class_State)
        .then((res) => {
          if (res.data.Data == 1) {
            if (row.Class_State == 1) {
              row.Class_State = 2;
            } else {
              row.Class_State = 1;
            }           
          }
          if (res.data.Data == 0) {
            this.$message.error("修改失败");
          }
        });
      },
      //审核
      ok(){
          this.$axios({url:
          "/api/EditCheckStat",
          method: "put", //请求方式
          data:this.formCheck
        }).then((res) => {
         if(res.data.Data>0){
             this.dialogCheck=false;
             this.GetCourse();
         }
         else{
             this.$message.error("修改失败");
         }
      });
      },
      //取消
      cancel(){
        //   this.form.Class_Name="";
        //   this.form.Class_ArticleDescription="";
          this.dialogVisible=false;
      },
      over(){
        this.dialogCheck=false;
      },
      //编辑
      sure(){
          this.$axios({url:
          "/api/EditCourse",
          method: "put", //请求方式
          data:this.form
        }).then((res) => {
         if(res.data.Data>0){
             this.dialogVisible=false;
             this.GetCourse();
         }
         else{
             this.$message.error("修改失败");
         }
      });
      }

    },
    
}
</script>
<style scoped>
.name{
width:150px
}

</style>