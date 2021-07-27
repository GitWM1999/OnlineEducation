<template>
    <div id="recorded">
     <div class="recordimg"  v-for="item in ClassList" :key="item.Class_Id" >

       <img :src="'http://localhost:58189'+item.Class_Img" style="width:319px;height:200px"  />

       <p class="likevideop">{{item.Class_Name}}</p>

       <p class="likevideop">已有1234人学习</p>
       
       <p class="likevideop">

           <span style="color:red">免费</span>

           <span>
               <el-button type="text" id="recordsc" class="an3" icon="el-icon-star-off" @click="skip(item.Class_Id)">收藏</el-button>
           </span>
       </p>
</div> 
    </div>
</template>
<script>

export default ({
    props:['TypeId'],
    props:['SecondId'],
    watch:{
      TypeId:function(val){
          this.Id=val;
      
         this.getlist();
      },
      SecondId:function(val){
         this.SId=val;
         
         this.getlist();
        
      }
    },
    data(){
        return{
           ClassList:[],
           Id:0,
           SId:0
        }
    },
    created(){
         this.getlist();
    },
    methods:{
        getlist(){
             this.$axios.get("/api/Freeclasses/GetClassList?TypeId="+this.Id+"&SecondId="+this.SId).then(res=>{
                this.ClassList=res.data;
            })
        },
        skip(classid){
            this.$router.push({
                path:'/freedetail',
                query:{
                    
                    id:classid
                }
            });
        }
    }
})
</script>
<style>
.recorded{
    width: 1200px;
    height: 1000px;
}
.recordimg{
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
#recordsc{
color: black;
    margin-left: 200px;;
}
</style>
