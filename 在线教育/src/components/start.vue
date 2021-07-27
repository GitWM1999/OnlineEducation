<template>

<div>

<!-- <p>

<img class="logo" src="/static/img/logo.png" />

<el-button type="text" class="an" >免费课程</el-button>

<el-button type="text" class="an">体系课程</el-button>

<el-button type="text" class="an">在线测评</el-button>

<el-button type="text" class="an">学习社区</el-button>

<el-input class="query" placeholder="请输入关键字"></el-input>

<el-button type="text" class="an">我的收藏</el-button>

<el-button type="text" class="an" icon="el-icon-shopping-cart-full"></el-button>

<el-button type="text" class="an">登录   /</el-button>

<el-button type="text" class="register">注册</el-button>

</p> -->

<div>

 <div style="float:left" class="left">
     <ul>
        <li>
            <el-button type="text" class="left-an">传媒设计</el-button>

            <a class="el-icon-caret-right"></a> 

            </li>
        <li>
            <el-button type="text" class="left-an">全栈产品</el-button>

            <a class="el-icon-caret-right"></a>
            
            </li>
        <li>
            <el-button type="text" class="left-an">网站前端</el-button>

            <a class="el-icon-caret-right"></a>
            
            </li>
        <li>
            <el-button type="text" class="left-an">大数据开发</el-button>

            <a class="el-icon-caret-right"></a>
            
            </li>
        <li>
            <el-button type="text" class="left-an">云计算开发</el-button>

            <a class="el-icon-caret-right"></a>
            
            </li>
        <li>
            <el-button type="text" class="left-an">物联网开发</el-button>

            <a class="el-icon-caret-right"></a>
            
            </li>
     </ul>
 </div>
 


<el-carousel trigger="click" height="360px" ref="carousel">
          <el-carousel-item v-for="item in bigScreen.images"
                            :key="item.name" :name="item.name">

           <img class="lubo" style="width:1050px;height:360px;" :src="item.url"/>

          </el-carousel-item>

</el-carousel>



 <p style="float:left">

  <img class="bottom" src="/static/img/bottom1.png" />

  <img class="bottom1" src="/static/img/bottom2.png" />

 </p>

</div>

<div class="middle1">

   <h2><b>学院课程体系</b>----紧跟技术发展及企业需求</h2>

 <p>
   
   <img class="middle" src="/static/img/yjs.png" />
  
   <img class="middle" src="/static/img/dsj.png" />

   <img class="middle" src="/static/img/wlw.png" />

 </p>

 <p class="middle-bottom">

   <img class="middle" src="/static/img/wz.png" />

   <img class="middle" src="/static/img/cm.png" />

   <img class="middle" src="/static/img/qz.png" />

 </p> 


</div>


<div class="middle2">

<p class="title">

   <label>热门直播课</label>
      
</p>

<hr class="line" />

 <el-radio-group v-model="tabPosition" style="margin-bottom: 30px;">
    <el-radio-button type="text" label="网站课程">网站课程</el-radio-button>
    <el-radio-button type="text" label="传媒课程">传媒课程</el-radio-button>
    <el-radio-button type="text" label="全栈课程">全栈课程</el-radio-button>
    <el-radio-button type="text" label="大数据课程">大数据课程</el-radio-button>
    <el-radio-button type="text" label="云计算课程">云计算课程</el-radio-button>
    <el-radio-button type="text" label="物联网课程">物联网课程</el-radio-button>
  </el-radio-group>

  <div class="likevideo">
   
    <div class="likevideoimg">

       <img src="/static/img/class.png" />

       <p class="likevideop">想学React.JS不用翻教材  百度大牛带你结合实践学习</p>

       <p class="likevideoper">已有1234人学习</p>
       
       <p class="likevideoprice">

           <span style="color:red">￥ 448.00</span>

           <span>
               <i id="sc" class="el-icon-star-off">收藏</i>
           </span>
       </p>
    </div>

  </div>

</div>



<div class="middle3">

<p class="title">

   <label>热门录播课</label>
      
</p>

<hr class="line" />

 <el-radio-group v-model="tabPosition" style="margin-bottom: 30px;">
    <el-radio-button type="text" label="网站课程">网站课程</el-radio-button>
    <el-radio-button type="text" label="传媒课程">传媒课程</el-radio-button>
    <el-radio-button type="text" label="全栈课程">全栈课程</el-radio-button>
    <el-radio-button type="text" label="大数据课程">大数据课程</el-radio-button>
    <el-radio-button type="text" label="云计算课程">云计算课程</el-radio-button>
    <el-radio-button type="text" label="物联网课程">物联网课程</el-radio-button>
  </el-radio-group>

  <div class="likevideo">
   
    <div class="likevideoimg">

       <img src="/static/img/class.png" />

       <p class="likevideop">想学React.JS不用翻教材  百度大牛带你结合实践学习</p>

       <p class="likevideoper">已有1234人学习</p>
       
       <p class="likevideoprice">

           <span style="color:red">￥ 448.00</span>

           <span>
               <i id="sc" class="el-icon-star-off">收藏</i>
           </span>
       </p>
    </div>

  </div>

</div>



<div class="middle4">

<p class="title">

   <label>限时秒杀课</label>
      
</p>

<hr class="line" />

<span style="margin-left:-1320px">距离秒杀开始:</span>

<div class="ms">

 <van-count-down class="mstime" :time="time"></van-count-down>

</div>
 

  <div class="likevideo">
   
    <div class="likevideoimg">

       <img src="/static/img/class.png" />

       <p class="likevideop">想学React.JS不用翻教材  百度大牛带你结合实践学习</p>

       <p class="likevideoper">已有1234人学习</p>
       
       <p class="likevideoprice">

           <span style="color:red">￥ 448.00</span>

           <span>
               <i id="sc" class="el-icon-star-off">收藏</i>
           </span>
       </p>
    </div>

  </div>

</div>

<div class="bottomfoot">

  <p class="bottomp">
      <el-button class="bottomazo" type="text">关于我们</el-button>
      <el-button class="bottomazo" type="text">联系我们</el-button>
      <el-button class="bottomazo" type="text">讲师招募</el-button>
      <el-button class="bottomazo" type="text">帮助中心</el-button>
      <el-button class="bottomazo" type="text">意见反馈</el-button>
      <el-button class="bottomazo" type="text">就业服务</el-button>
  </p>

  <p class="bottomp">
     <el-button class="bottomaz" type="text">邮箱：100193</el-button>
     <el-button class="bottomaz" type="text">电话：400-008-0897</el-button>
     <el-button class="bottomaz" type="text">业务及合作：bjebin@163.com</el-button>
  </p>
  <p class="bottomp">
    <el-button class="bottomazed" type="text">八维教育</el-button>
    <el-button class="bottomazed" type="text">京公网备案1101185263855</el-button>
    
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

import Vue from 'vue';

import { Swipe, SwipeItem } from 'vant';

Vue.use(Swipe);

Vue.use(SwipeItem);

import { CountDown } from 'vant';

Vue.use(CountDown);

import { Icon } from 'vant';

Vue.use(Icon);

export default {
  name:"start",
  data(){
    
    return{
        activeName: 'first',
        tabPosition: 'left',
        bigScreen: {
        images: [
          {
            name: 'bigScreen01',
            url: 'static/img/lubo1.png'
          },
          {
            name: 'bigScreen02',
            url: 'static/img/lubo2.jpeg'
          },
          {
            name: 'bigScreen03',
            url: 'static/img/lubo3.jpeg'
          },
          {
            name: 'bigScreen04',
            url: 'static/img/lubo4.jpeg'
          }
        ]
       },
       time: 30 * 60 * 60 * 100,

      };
  },
  methods: {
      handleClick(tab, event) {
        console.log(tab, event);
      }
    }

}
</script>

<style>
.lubo{
  margin-left: -218px;
}
.left{
    width: 200px;
    height: 360px;
    line-height: 50px;
    background-color: darkslateblue;
    margin-left: 50px;
}

li{
    
    list-style: none;
    margin-left: 25px;
    line-height: 50px;
}
a{
  color:white;
  
} 
.left-an{
  margin-top: 15px;
  color:white;
}
.bottom{
    width: 600px;
    height: 120px;
    margin-left: 50px;
    margin-top: 20px;
}
.bottom1{
    width: 600px;
    height: 120px;
    margin-left: 50px;
    margin-top: 20px;
}
.middle1{
    margin-top: 190px;
    margin-left: -218px;
}
.middle{
    width: 380px;
    height: 180px;
    margin-left: 50px;
}
.middle-bottom{
    margin-top: 25px;
}
label{
    font-size: 20px;
    margin-left: 50px;
    
}
.title{
    margin-top: 30px;
    margin-left: -1373px;
}
.line{
     border-bottom:1px solid black;
     width: 100px;
     margin-left: 50px;
     margin-top: 10px;
}

.likevideo{
    width: 1600px;
    height: 680px;
}
.likevideoimg{
    width:319px;
    height: 320px;
    margin-left: 50px;
    
    border-radius: 4px;
    box-shadow:0 0 2px 2px whitesmoke;
}
.likevideop{
    margin-top: 15px;
    
}
.mstime{
    margin-left: -1380px;
    color: white;
}
#sc{
    margin-left: 190px;
}
.ms{
    margin-left: 50px;
    height: 20px;
    background-color: red;
    
}
.bottomfoot{
    width: 100%;
    height: 180px;
    background-color: black;
   
    
}
.bottomp{
    
    line-height: 30px;
    width: 643px;
}
.bottomaz{
    color: white;
    margin-top: 10px;
    margin-left: -35px;
}
.bottom-right1{
    width: 120px;
    height: 90px;
    margin-top: -130px;
    margin-left: 1100px;
}
.bottom-right2{
    width: 130px;
    height: 90px;
    margin-top: -90px;
    margin-left: 1200px;
}
.text{
    margin-left: 16px;
}
.el-radio-group{
  margin-left: -595px;
}
.likevideoper{
  margin-left: -218px;
}
.likevideoprice{
  margin-left: -30px;
  margin-top: 20px;
}
.bottomazed{
  margin-left: -240px;
  color: white;
  margin-top: 10px;
}
.bottomazo{
  margin-left: -50px;
  color: white;
  margin-top: 10px;
}
</style>
