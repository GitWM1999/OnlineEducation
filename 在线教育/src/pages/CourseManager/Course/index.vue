<template>
<div>

  <el-tabs >
    <!-- 直播课 -->
  <el-tab-pane label="录播课">
    <el-container>
        <el-main>
    课程名称：<el-input v-model="courseName" placeholder="请输入名称" class="name">
    </el-input>
    状态：<el-select v-model="State" size="mini" clearable  placeholder="请选择">
    <el-option
      v-for="item in options"
      :key="item.value"
      :label="item.label"
      :value="item.value">
    </el-option>
  </el-select>
  是否免费：<el-select v-model="free" size="mini" clearable  placeholder="请选择">
    <el-option
      v-for="item in Freeoptions"
      :key="item.value"
      :label="item.label"
      :value="item.value">
    </el-option>
  </el-select>
  上下架：<el-select v-model="Checks" size="mini" clearable  placeholder="请选择">
    <el-option
      v-for="item in Checkoptions"
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
              <img :src="imgURL + scope.row.Class_Img"
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

    <el-table-column fixed="right" label="操作" width="120">
        <template slot-scope="scope">
            <el-button type="text" size="small" @click="Compile(scope.row)">编辑</el-button>
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

    </el-main>
  </el-container>
  </el-tab-pane>

  <!-- 直播课 -->
  <el-tab-pane label="直播课">
      <div>
        课程名称：<el-input v-model="className" placeholder="请输入名称" class="name">
    </el-input>
    状态：<el-select v-model="videoState" size="mini" clearable  placeholder="请选择">
    <el-option
      v-for="item in Videooption"
      :key="item.value"
      :label="item.label"
      :value="item.value">
    </el-option>
  </el-select>
  是否免费：<el-select v-model="videofree" size="mini" clearable  placeholder="请选择">
    <el-option
      v-for="item in videofreeoptions"
      :key="item.value"
      :label="item.label"
      :value="item.value">
    </el-option>
  </el-select>
  
  <el-button type="primary" @click="searchVideo()">查询</el-button>
    <!-- 直播 -->
          <div class="goodshow-list">
            <dl v-for="(v,i) in  videoData" :key="i" style="float:left">
              <dt>
                <img :src="imgURL+v.OutPutVideoImg" style="width:200px;height:200px"  />
                <span id="span1" v-if="v.OutPutVideoState===2">已结束
                </span>
                <span id="span2" v-if="v.OutPutVideoState===1">直播中
                </span>
              </dt>
              <dd>
                <p>{{v.OutPutCourseTitle}}&emsp;&emsp;&emsp;&emsp;&emsp;<span v-if="v.OutPutCoursePrice==0">免费</span>
                <span v-if="v.OutPutCoursePrice!=0" style="color:red">￥{{v.OutPutCoursePrice}}</span></p>
                <p>{{v.OutPutTeacher_Name}} &emsp;&emsp;&emsp;&emsp;&emsp;{{v.OutPutBeginTime}}</p>
                
                <li>
                  <a v-if="v.OutPutVideoState===1" @click="enterVideo(v.OutPutVideoId)">进入直播</a>&emsp;&emsp;
                         <a v-if="v.OutPutVideoState===2" @click="enter(v.OutPutVideoId)">回看</a>&emsp;&emsp;
                         <a v-if="v.OutPutVideoState===2" style="margin-left:60px" @click="del(v.OutPutVideoId)">删除</a>
                         
                         <span v-if="v.OutPutVideoState===1">
                          <el-switch :value="v.OutPutVideoState==1?true:false"
                          active-text="开启"
                          inactive-text="关闭"                
                          @change="changeVideoState(v.OutPutVideoId,v.OutPutVideoState)">
                           </el-switch>
                         </span>
                </li>
              </dd>
            </dl>
          </div>
        </div>

  </el-tab-pane>
  
</el-tabs>
    
</div>
</template>

<script>
export default {
    data(){
        return{
            imgURL:"",
            courseName:'',
            tableData:[],
            videoData:[],
            value:true,
            stat:true,
            State:'',
            Checks:'',
            free:'',
            className:'',
            videoState:'',
            videofree:'',
            dialogVisible:false,
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
            form:{
                Class_Id:0,
                Class_Name:'',
                Class_Price:0,
                Class_ArticleDescription:''
            },
            Videooption:[
               {
                    value:1,
                    label:'直播中'
                },
                {
                    value:2,
                    label:'已结束'
                }
            ],
            videofreeoptions:[
              {
                    value:1,
                    label:'是'
                },
                {
                    value:2,
                    label:'否'
                }
            ],
            formVideo:{
              InPutVideoId:0,
              InPutVideoState:0
              
            }
        }
    },
    //第一次加载
    created(){
        this.GetCourse();
        this.GetVideo();
         this.imgURL=this.APIurl.API.apiUrl.imgURL;
    },
    methods:{

        //显示  录播课
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
        "/api/GetCourse?courseName="+this.courseName+"&state="+states+"&check="+putaway+"&free="+freemoney,
        method: "get", //请求方式
      }).then((res) => {
        console.log(res.data.Data); //在控制台查看数据
        this.tableData = res.data.Data; //把数据赋值给表单
        //this.totalcount = res.data.totalCount;
      });
      },
      //显示  直播课
      GetVideo(){
        var state=0;
        var free=0;
        if(this.videoState==''){
          state=0;
        }
        else{
          state=this.videoState;
        }
        //是否免费
        if(this.videofree==''){
          free=0;
        }
        else{
          free=this.videofree;
        }

        this.$axios({url:
        "/api/GetVideo?name="+this.className+"&stat="+state+"&videofree="+free,
        method: "get", //请求方式
      }).then((res) => {
        console.log(res.data.Data); //在控制台查看数据
        this.videoData = res.data.Data; //把数据赋值给表单
        //this.totalcount = res.data.totalCount;
      });
      },
      //查询
      search(){
          this.GetCourse();
      },
      searchVideo(){
          this.GetVideo();
      },
      //直播修改状态
      changeVideoState(id,stat){
          this.formVideo.InPutVideoId=id;
          this.formVideo.InPutVideoState=stat;
           this.$axios({url:
          "/api/EditVideoStat",
          method: "put", //请求方式
          data:this.formVideo
        }).then((res) => {
         if(res.data.Data>0){
             this.GetVideo();
         }
         else{
             this.$message.error("修改失败");
         }
      });
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
      //编辑
      Compile(row){
          this.dialogVisible=true;
          if(row!=null){
              this.form=row;
          }
      },
      //取消
      cancel(){
        //   this.form.Class_Name="";
        //   this.form.Class_ArticleDescription="";
          this.dialogVisible=false;
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
      },
      //删除直播
      del(id){

        if(confirm("确定删除吗")){
            this.$axios.delete("/api/DelVideo?id="+id).then((res)=>{
          if(res.data.Data>0){
            this.$message({
              type:'success',
              message:'删除成功！'
            })
            this.GetVideo();
          }
          else{
            this.$message.error("删除失败!!!");
          }
        })
      }
      }
      
    },
    
}
</script>
<style scoped>
.name{
width:150px
}
.goodshow-list {
  flex: 1;
  height: 100%;
  width: 100%;
  display: flex;
  padding: 0 20px;
  overflow-y: auto;
}
dl {
  width: 43%;
  height: 346px;
  margin: 10px;
  background-color: white;
  padding: 5px 5px 0 5px;
  overflow: hidden;
}

dt {
  width: 100%;
  height: 130px;
}
dt img {
  width: 120%;
  height: 120%;
  
}
dd {
  width: 100%;
  height: 50px;
  margin-top:76px;
}
dd p {
  font-size: 14px;
}
dd li {
  width: 300px;
  height: 26px;
  display: flex;
  align-self: center;
  /* justify-content: space-around;
  margin-left:-60px; */
}
#span1{
  position: relative;
  margin-left:107px;
  top: -193px;
  color: red;
}
#span2{
  position: relative;
  margin-left:107px;
  top: -193px;
   color: rgb(234, 250, 7);
}
</style>