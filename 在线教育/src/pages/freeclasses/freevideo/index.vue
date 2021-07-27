<template>
    <div class="video">
<div class="videoImg"  v-for="item in Video" :key="item.VideoId" >

<div v-if="item.VideoState==2">
     
     <van-button square type="primary" class="videobtn1"><van-count-down :time="item.DistanceTime" class="videotime"/></van-button>
     <img :src="'http://localhost:58189'+item.VideoImg" style="width:319px;height:200px"  />
      
</div>
<div v-else>
     <van-button square type="primary" class="videobtn2">直播中</van-button>
     <img :src="'http://localhost:58189'+item.VideoImg" style="width:319px;height:200px"  />
</div>

       <p class="likevideop">{{item.CourseTitle}}</p>

       <p class="likevideop">已有1234人学习</p>
       
       <div>
           <p class="likevideop">
           
           <span>开播时间:{{item.StrVideoTrueBeginTime}}</span>

           <span>
               <el-button type="text" id="videosc" class="an3" icon="el-icon-star-off" @click="skip(item.VideoState,item.VideoId)">收藏</el-button>
           </span>
       </p>
       </div>
</div>

</div>
</template>
<script>

export default({
    
    name:"freevideo",
    props:['TypeId'],
    props:['SecondId'],
    watch:{
        
      SecondId:function(val){
         this.SId=val;
          alert(val);
         this.GetVideo();
      },
      TypeId:function(val){
          this.Id=val;
          alert(val);
         this.GetVideo();
      }
    },
    data(){
        return{
          Video:[],
          Id:0,
          SId:0
        }
    },
    created(){
       this.GetVideo()
    },
    methods:{
       GetVideo(){
        this.$axios({
            url:"/api/Freeclasses/GetFreeVideo?TypeId="+this.Id+"&SecondId="+this.SId,
            methods:"get"
        }).then(res=>{
            this.Video=res.data;
        })
       },
       skip(state,VideoId){
           if(state==2){
                this.$router.push({
                path:'/live',
                query:{
                    id:VideoId
                }
            });
           }
           if(state==1){
               
               this.$router.push({
                path:'/videodetail',
                query:{
                    id:VideoId
                }
            });
           }
       }
    }
})
</script>

<style>
.video{
    width: 1200px;
    height: 1000px;
}
.videoImg{
width:319px;
    height: 320px;
    margin-left: 50px;
    margin-top:30px;
    border-radius: 4px;
    box-shadow:0 0 2px 2px whitesmoke;
    float: left;
    box-sizing: border-box;
    text-align: left;
}
#videosc{
color: black;
    margin-left: 250px;
    margin-top: -25px;
}
.videobtn1{
    border-radius: 8px;
    width:80px;
    height:35px;
    background-color: unset;
    background: rgb(240, 0, 0,0.5);
    position: absolute;

}
.videobtn2{
      border-radius: 8px;
    width:80px;
    height:35px;
    background-color: unset;
    background: rgb(0, 240, 0,0.5);
    position: absolute;
}
.videotime{
    color:white;
}
</style>