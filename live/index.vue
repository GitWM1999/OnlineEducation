<template>
    
<div>
   <img class="wzm" src="/static/img/wzm.png" />

   <div class="right">
       
       <h4>距离直播开始还有</h4>

       <div class="time">
        <ul>
            <li class="tn">{{this.day}}</li>
            <li class="cn">天</li>
        </ul>
       </div>

        <div class="time">
         <ul>
            <li class="tn">{{this.hour}}</li>
            <li class="cn">小时</li>
        </ul>
       </div>

        <div class="time">
        <ul>
            <li class="tn">{{this.minute}}</li>
            <li class="cn">分钟</li>
        </ul>
       </div>

        <div class="time">
         <ul>
            <li class="tn">{{this.second}}</li>
            <li class="cn">秒</li>
        </ul>
       </div>

    <p class="person">
    <span style="color:red">{{num}}</span>
    人预约
    </p>

    <el-button type="danger" style="width:170px;margin-left:15px;margin-top:50px" round>已预约</el-button>
 
    <p style="color:gray;margin-left:0px;margin-top:20px">免费</p>
   </div>

</div>

</template>

<script>
export default {
  data() {
    return {
      day:0,
      hour:0,
      minute:0,
      second:0,
      num:5,
      VideoList:[],
      form:{}
    };
  },
  created(){
     this.GetVideo();
     this.currentTime();
  },
  methods:{
      GetVideo(){
      
          this.$axios({
              url:"/api/Freeclasses/GetFreeVideo?VideoId="+this.$route.query.id,
              method:"get"
          }).then(res=>{
              this.VideoList=res.data;
              this.VideoList.forEach(item=>{
                  if(item.VideoId==this.$route.query.id){
                      this.form=item;
                  }
              })
          })
          
      },
      currentTime(){
          setInterval(this.countTime,1000);
      },
      countTime(){
          this.form.DistanceTime=this.form.DistanceTime-1000;
         
           this.day=Math.floor(this.form.DistanceTime/(1000*60*60*24));
                      if(this.day>1){
                        this.hour=Math.abs(Math.floor((this.form.DistanceTime-(1000*60*60*24))/(1000 * 60 * 60)));
                      }
                      else{
                        this.hour=Math.abs(Math.floor(((1000*60*60*24)-((1000*60*60*24)-this.form.DistanceTime))/(1000 * 60 * 60)));
                      }
                      if(this.day>1){
                          this.minute=Math.floor(Math.abs((this.form.DistanceTime-((1000*60*60*24)+((1000 * 60 * 60)*this.hour)))/(1000 * 60)));
                      }
                     else{
                         this.minute=Math.floor((this.form.DistanceTime-(((1000 * 60 * 60)*this.hour)))/(1000*60))
                     }
                      if(this.day>1){
                          this.second=Math.floor(Math.abs((this.form.DistanceTime-((1000*60*60*24)+((1000 * 60 * 60)*this.hour)+((1000*60)*this.minute)))/(1000)));
                      }else{
                          this.second=Math.floor(Math.abs((this.form.DistanceTime-(((1000 * 60 * 60)*this.hour)+((1000*60)*this.minute)))/(1000)));
                      }
                    
                   
      }
      
  }
  
}
</script>


<style>

  .wzm{
      width: 600px;
      height: 400px;
      margin-left: 175px;
      float: left;
  }
  .right{
      width: 200px;
      height: 400px;
      background-color: black;
      float: left;
      
  }
  h4{
      color: white;
      margin-left: 25px;
      margin-top: 30px;
  }
.time{
    width: 40px;
    height: 80px;
    border: 1px solid gray;
    margin-left: 7px;
    float: left;
    margin-top: 20px;
}
.person{
    color: white;
    margin-left: 10px;
    margin-top: 150px;
}
.cn{
    color: gray;
    font-size: 12px;
    list-style: none;
    margin-left: -1px;
    margin-top: 8px;
}
.tn{
    list-style: none;
    color: white;
    margin-left: -1px;
    font-size: 24px;
    margin-top: 15px;
}
</style>


