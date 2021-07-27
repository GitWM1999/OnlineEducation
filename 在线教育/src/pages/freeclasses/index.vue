<template>
<div style="height:100%" >

<!-- <div v-for="item in NavigationList" :key="item.NavigationId" class="box3">
    <div class="box4">
    <el-button type="text" class="an">{{item.NavigationTitle}}</el-button>
    </div>
<el-button type="text" class="an">八维在线教育首页</el-button>
<el-button type="text" class="an">免费课程</el-button>
<el-button type="text" class="an">体系课程</el-button>
<el-button type="text" class="an">在线测评</el-button>
<el-button type="text" class="an">学习社区</el-button>
<el-input class="query" placeholder="请输入关键字"></el-input>
<el-button type="text" class="an">我的收藏</el-button>
<el-button type="text" class="an" icon="el-icon-shopping-cart-full"></el-button>
<el-button type="text" class="an">我的课程</el-button>
</div> -->
<div class="free1">
    <img class="img1" src="/static/img/free1.png" />
    <p class="p" style="font-size:20px">
        <b style="font-size:25px;padding-right:15px">免费课程</b>
        真实项目实战演练
    </p>

    <div class="free2">
             <b class="b1">方向:</b>
             <div class="free3" v-for="item in ClassType" :key="item.Type_Id">
                 <div>
                 <el-button type="text" class="fbn1" @click="skip(item.Type_Id)">{{item.Type_Name}}</el-button>
                 </div>
     <!-- <el-button type="text" class="an">网站前端</el-button>
       <el-button type="text" class="an">传媒设计</el-button>
        <el-button type="text" class="an">全栈产品</el-button>
         <el-button type="text" class="an">大数据开发</el-button>
          <el-button type="text" class="an">云计算开发</el-button>
           <el-button type="text" class="an">物联网开发</el-button> -->
           </div>
    </div>
   <div class="free2">
             <b class="b1">分类:</b>
             <div class="free3" v-for="item in ClassSecondType" :key="item.SecondType_Id">
                 <el-button type="text" class="fbn2" @click="skip2(item.SecondType_Id)">{{item.SecondType_Name}}</el-button>
     <!-- <el-button type="text" class="an2">Vue.js</el-button>
          <el-button type="text" class="an2">Typescript</el-button>
           <el-button type="text" class="an2">React.JS</el-button>
            <el-button type="text" class="an2">HTML/CSS</el-button>
             <el-button type="text" class="an2">JavaScript</el-button>
              <el-button type="text" class="an2">Angular</el-button>
               <el-button type="text" class="an2">Node.js</el-button>
                <el-button type="text" class="an2">JQuery</el-button>
                 <el-button type="text" class="an2">Bootstrap</el-button>
                  <el-button type="text" class="an2">Sass/Less</el-button>
                   <el-button type="text" class="an2">WebApp</el-button>
                    <el-button type="text" class="an2">小程序前端</el-button>
                     <el-button type="text" class="an2">CSS</el-button>
                      <el-button type="text" class="an2">HTML5</el-button>
                       <el-button type="text" class="an2">CSS3</el-button> -->
           </div>
    </div>
    <div class="free2">
             <b class="b1">模式:</b>
             <div class="free3">
   <router-link  class="fbn2" to="/recorded">录播课</router-link>
   <router-link  class="fbn2" to="/freevideo">直播课</router-link>

           </div>
    </div>

</div>
<div class="frame" v-if="this.SecondId==0">
 <router-view :TypeId="TypeId"></router-view>
</div>
<div class="frame" v-else>
     <router-view :SecondId="SecondId"></router-view>
</div>
<div class="bottomfoot">

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

</div>
</div>

</template>
<script>




export default({
    data(){
        return{
            NavigationList:[],
            ClassType:[],
            ClassSecondType:[],
            TypeId:0,
            SecondId:0
        }
    },
    created(){
        this.getlist();
        this.GetClassType();
        this.GetClassSecondType(this.TypeId);
    },
    methods:{
        getlist(){
            // this.$axios.all([
            //     this.$axios.get("/api/Navigation/GetNavigationData"),
            //     this.$axios.get("/api/Freeclasses/GetClassType"),
            //     this.$axios.get("/api/Freeclasses/GetGetClassSecondType")
            // ]).then(this.$axios.spread(function(v1,v2,v3){

            //   alert(JSON.stringify(v2.data));
            //        this.NavigationList=v1.data.query;
            //        this.ClassType=v2.data;
            //        this.ClassSecondType=v3.data;

            // }))

           this.$axios({
               url:"/api/Navigation/GetNavigationData",
               method:"get"
           }).then(res=>{
                 this.NavigationList=res.data.query;
            })
        },
        GetClassType(){

                 this.$axios.get("/api/Freeclasses/GetClassType").then(res=>{
                     this.ClassType=res.data;
                 })
        },
        GetClassSecondType(TypeId){
                this.$axios.get("/api/Freeclasses/GetClassSecondType?TypeId="+TypeId).then(res=>{
                    this.ClassSecondType=res.data;
                })
        },
        skip(id){
            this.SecondId=0;
           this.TypeId=id;
          this.GetClassSecondType(id);
        },
        skip2(id){
          this.SecondId=id;
        }

    }
})
</script>

<style>
.fbn1{
   font-size: 21px;
   color: black;
   margin-left: 50px;
}

.fbn2{
   font-size: 15px;
   color: black;
   margin-left: 50px;

}
.an3{
    color: black;
    margin-left: 200px;;

}
.query{
    margin-left: 30px;
    width: 240px;
    height: 42px;
    margin-top: -5px;
    border: 1px black solid;

}
.register{
   font-size: 21px;
   color: black;


}
.free1{

    background-color:rgb(245, 245, 245);
    width: 1200px;
    height: 300px;
    display: inline-block;
    text-align:left;

}
.free2{
   margin-left: 60px;
    margin-top:20px;


}
.free3{
    margin-top:-35px;
 display: inline-block;
}
.img1{
    margin-left: 50px;
    margin-top: 50px;
    width: 50px;
    height: 45px;

}
.p{
    margin-left: 110px;
    margin-top: -40px;
}
.b1{
    font-size:20px;
    margin-right:-40px;
    clear:both;
}
.frame{
    width: 1200px;
    height: 1000px;
    margin-left:110px;
}
.likevideoimg{

    width:319px;
    height: 320px;
    margin-left: 50px;
    margin-top:30px;
    border-radius: 4px;
    box-shadow:0 0 2px 2px whitesmoke;
    float: left;
    box-sizing: border-box;
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
.bottomaz{
    color: white;
    margin-top: 15px;
    margin-left: 60px;
}
</style>
