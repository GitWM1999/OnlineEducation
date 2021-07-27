<template>
    <div style="height:100%">
    
        <!--头部-->
        <div class="firest"> 
        <span>
        <img class="logo" style="margin-top:10px" src="/static/img/cs.png" /></span>
        &emsp;<div class="tou"><b style="font-size:25px;padding-right:15px;margin-top:20px;">在线测试</b>
        真实项目实战演练</div>

        <!--方向-->  
        <div style="width:800px">                                                        
        <p style="font-size:21px;font-weight:700;margin-top:14px;">方向：    
        <el-button v-for="item in ClassType" :key="item.type_Id" @click="fx(item.type_Id)" type="text" class="an" >{{item.type_Name}}</el-button>
        </p>
        </div>
        
        <!--搜索-->
        <div style="float:right;margin-top:-52px;margin-right:337px;">
        <el-input style="width:320px"  v-model="ConfignName" placeholder="搜索试卷名称"></el-input>
        <el-button  type="info" icon="el-icon-search" @click="onSubmit()"></el-button>
        </div>
        
        <!--分类-->
        <div>
        <p style="font-size:21px;font-weight:700;">分类：     
        <el-button type="text" class="an" v-for="item in ClassSecondType" :key="item.secondType_Id" @click="fl(item.secondType_Id)" >{{item.secondType_Name}}</el-button>
        </p>
        </div>
        
        </div>
        
        <!--测试题目-->
        <div class="second">
        <div class="st"  v-for="item in TestQuestions" :key="item.testpaperid" @click="exam(item.testbh)" >
          <p style="margin-top:30px;margin-left:30px">{{item.testpapername}}</p>
          <p style="margin-top:30px;margin-left:30px">更新：{{item.settime}}&emsp;&emsp;下载：123&emsp;&emsp;浏览：2345</p>
        </div>


        </div>
        
        <!--底部-->
      <!-- <div class="foot">
      <p class="bottomp">
      <el-button class="bottomaz" type="text">关于我们</el-button>
      <el-button class="bottomaz" type="text">联系我们</el-button>
      <el-button class="bottomaz" type="text">讲师招募</el-button>
      <el-button class="bottomaz" type="text">帮助中心</el-button>
      <el-button class="bottomaz" type="text">意见反馈</el-button>
      <el-button class="bottomaz" type="text">就业服务</el-button>
      </p>

  <p class="bottomp">
     <el-button class="bottomaz" type="text">邮箱：100193</el-button>
     <el-button class="bottomaz" type="text">电话：400-008-0897</el-button>
     <el-button class="bottomaz" type="text">业务及合作：bjebin@163.com</el-button>
  </p>
  <p class="bottomp">
    <el-button class="bottomaz" type="text">八维教育</el-button>
    <el-button class="bottomaz" type="text">京公网备案1101185263855</el-button>
  </p>

  <div class="bottom-right1">
     <ul>
         <li>
             <el-button icon="el-icon-star-off" circle></el-button>
         </li>
         <li class="text" style="color:white">收藏本站</li>
     </ul>
  </div>

  <div class="bottom-right2">
     <ul>
         <li>
             <el-button icon="el-icon-user" circle></el-button>
         </li>
         <li class="text" style="color:white">微信公众号</li>
     </ul>
  </div>

        </div> -->
    </div>
</template>


<script>

export default({
    data(){
        return{         
            ClassType:[],       //方向
            ClassSecondType:[], //分类
            TestQuestions:[], //题目
            ConfignName:"", //查询名
            typeid:0,
            secondid:0,  //二级
        }
    },
    created(){     
        this.GetClassType();
        this.GetClassSecondType();
        this.GetTestQuestions();
    },
    methods:{
        //方向
        GetClassType(){          
                 this.$axios.get("/api/Exam/ClassType").then(res=>{
                     this.ClassType=res.data.data;
                 })
        }, 
        //分类
        GetClassSecondType(){
                this.$axios.get("/api/Exam/ClassSecondType?classType="+this.typeid).then(res=>{
                    this.ClassSecondType=res.data.data;
                })
        }, 
        //测试题目
        GetTestQuestions(){      
        this.$axios({
        url: "/api/Exam/TestOnline?quesName="+this.ConfignName+"&oneType="+this.typeid+"&secondType="+this.secondid,
        methods: "get",
      }).then(res => {
        this.TestQuestions = res.data.data;
      });
        },  
        //查询
        onSubmit(){
        this.GetTestQuestions()
        }, 
        //方向查询
        fx(ty){
         this.typeid=ty;
         this.GetClassSecondType();
         this.GetTestQuestions();
        }, 
        //分类查询
        fl(tt){
         this.secondid=tt;
         this.GetTestQuestions();
        },
        //点击跳转试题页面
        exam(testId)
        {
        this.$router.push({
                path:'/examstart',
                query:{
                    id:testId
                }
            });
        }, 
    }
})
</script>

<style>

.firest{
    background-color:gainsboro;  
    margin-left: 20px; 
}
.an{
    font-size:16px;
}
.foot{
    /* width: 1200px; */
    height: 180px;
    background-color: rgb(0, 7, 3);
    margin-left: 50px;    
}
.bottomp{
    
    line-height: 30px;
    width: 643px;
}
.bottomaz{
    color: white;
    margin-top: 15px;
    margin-left: 60px;
}
.bottom-right1{
    width: 120px;
    height: 90px;
    margin-top: -150px;
    margin-left: 900px;
}
.bottom-right2{
    width: 130px;
    height: 90px;
    margin-top: -90px;
    margin-left: 1000px;
}
.second{
    height: 650px;
}
.st{

    height: 140px;
    width: 500px;
    border: 1px solid gray;
    margin-left: 80px;
    margin-top: 30px;
    float: left;
}
.tou{

    margin-right: 1217px;
    margin-top: 39px;
    width: 400px;
    float: right;
}
</style>