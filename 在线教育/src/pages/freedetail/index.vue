<template>
    <div class="box"  >
        <div v-for="item in ClassDetail" :key="item.Class_Id">
            <div class="box1">
            
              <div class="box2">
                 <video-player class="vjs-custom-skin" :options="playerOptions"></video-player>
              </div>

            <div class="box3" >
                <p class="p1">{{item.Class_Name}}</p>
                <div class="box4">
                    <p class="p2">价格:</p>
                    <p class="p3">免费</p>
                </div>
                <p class="p4">讲师:</p>
                <p class="p5">{{item.Teacher_Name}}</p>
                <el-button type="danger" round class="btn1">观看</el-button>
                 <span>
               <a id="sc" class="el-icon-star-off">收藏</a>
           </span>
            </div>
           
        </div>
  <div class="box5">
            <el-tabs v-model="activeName" @tab-click="handleClick" stretch="20px">
    <el-tab-pane label="课程介绍" name="first">
        <div class="box6">
            {{item.Class_ArticleDescription}}
        </div>
    </el-tab-pane>
    <el-tab-pane label="课程大纲" name="second">
        <div class="box6" v-for="item in ClassSecondType" :key="item.SecondType_Id">
            <el-button type="text" class="an">{{item.SecondType_Name}}</el-button>
        </div>
    </el-tab-pane>
  </el-tabs>
</div>
        </div>
    </div>
</template>


<script>

//引入video样式
import 'video.js/dist/video-js.css'
import 'vue-video-player/src/custom-theme.css'

//引入hls.js
import 'videojs-contrib-hls.js/src/videojs.hlsjs'

export default ({
    data(){
        return{
      ClassDetail:[],
      form:{},
      ClassSecondType:[],
      playerOptions: {
          playbackRates: [0.7, 1.0, 1.5, 2.0], //播放速度
          autoplay: false, //如果true,浏览器准备好时开始回放。
          controls: true, //控制条
          preload: 'auto', //视频预加载
          muted: false, //默认情况下将会消除任何音频。
          loop: false, //导致视频一结束就重新开始。
          language: 'zh-CN',
          aspectRatio: '16:9', // 将播放器置于流畅模式，并在计算播放器的动态大小时使用该值。值应该代表一个比例 - 用冒号分隔的两个数字（例如"16:9"或"4:3"）
          fluid: true, // 当true时，Video.js player将拥有流体大小。换句话说，它将按比例缩放以适应其容器。
          sources: [{
            src: 'http://1305739671.vod2.myqcloud.com/ebfb1bf4vodtranscq1305739671/912ac0973701925921231317361/v.f100010.mp4',//播放地址
            type: 'video/mp4'
          }],
          poster: "http://1305739671.vod2.myqcloud.com/15112e4cvodcq1305739671/912ac0973701925921231317361/3701925921231459885.jpeg", //你的封面地址
          width: document.documentElement.clientWidth,
          notSupportedMessage: '此视频暂无法播放，请稍后再试' //允许覆盖Video.js无法播放媒体源时显示的默认信息。
        }
        }
    },
    created(){
        this.GetList();
    },
    methods:{
        GetList(){
          this.$axios({
              url:"/api/Freeclasses/GetClassDetail?classId="+this.$route.query.id,
              method:"get"
          }).then(res=>{
              this.ClassDetail=res.data;
              this.ClassDetail.forEach(item => {
                  if(item.Class_Id==this.$route.query.id){
                     this.form=item;
                    this.GetClassSecondType(this.form.Class_ClassType);
                  }
              });
           
          })
        },
        GetClassSecondType(id){
            this.$axios({
                url:"/api/Freeclasses/GetClassSecondType?classType="+id,
                method:"get"
            }).then(res=>{
               this.ClassSecondType=res.data;
            })
        }
    }
})
</script>

<style>
.an{
       font-size: 21px;
   color: black;
   margin-left: 50px;
}
#sc{
    color: white;
    margin-left: 425px;
}
.box{
     background-color:rgb(245, 245, 245);
      text-align: left;
}
.box1{
   
   width: 1200px;
    height: 330px;
    background-color: black;
       display: inline-block;
       text-align: left;
       margin-left: 175px;
}
.box2{
  
    margin-left :35px;
    margin-top:30px;
    top: 55px;
    width: 500px;
    height: 250px;
    background-color:black;
}
.box3{
 
    margin-top:-280px;
     margin-left :560px;
      width: 600px;

    height: 250px;
}
.box4{
    width: 550px;
    height: 50px;
     background-color:white;
}
.box5{
    
    width: 1200px;
    height: 50px;
    border-radius: 15px;
    background-color:white;
    margin-top: 30px;
    margin-left:175px;;
}
.box6{
    width: 1200px;
    height: 500px;
    border-radius: 15px;
    background-color:white;
    margin-top: 30px;
    margin-left:20px;;
}
.p1{
    color: white;
    font-size: 18px;
    margin-left:0px;
    margin-top:30px;
    
}
.p2{
    color:gray;
    font-size:15px;
    padding-top:15px;
    top: 105px;
    margin-left: 15px;
}
.p3{
    color:red;
    font-size:15px;
    margin-top:-30px;
    top: 105px;
    margin-left: 70px;
}
.p4{
    margin-top: 20px;
    color:white;
    font-size:15px;
    
}
.p5{
    margin-top:-30px;
       margin-left: 50px;
    color:white;
    font-size:15px;
}
.sp{
    color: gainsboro;

}
.btn1{
    margin-top:70px ;
}
</style>