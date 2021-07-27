<template>
<div class="da">
    <div class="header">
          <div class="photo">
               <el-avatar icon="el-icon-user-solid"></el-avatar>
              
         </div>
           <div class="edit"  style="font-size:22px">
                <b>程序猿342322<a href="http://localhost:8080/#/start"><i class="el-icon-edit"></i></a></b>
          </div>


    </div>   
    <div class="">

    </div>
    <div class="zuo">

          <el-tabs :tab-position="tabPosition" style="height: 700px;">
            <el-tab-pane label="我的课程">
              

        <el-tabs v-model="activeName" @tab-click="handleClick">
            <el-tab-pane label="全部" name="first">
              <br>
        
              <p>目前没有任何课程，<el-button type="text" @click="shouye()">找找课程</el-button></p>


            </el-tab-pane>
            <el-tab-pane label="免费课" name="second">
              <p>目前没有任何课程，<el-button type="text" @click="shouye()">找找课程</el-button></p>
            </el-tab-pane>
            <el-tab-pane label="体系课" name="third">
              <p>目前没有任何课程，<el-button type="text" @click="shouye()">找找课程</el-button></p>
            </el-tab-pane>
          </el-tabs>
          <br><br><br><br><br><br>
          <p style="font-size:10px">推荐课程</p><br>
         
        <p class="tu" v-for="item in table2data" :key="item.id">
            <img class="logo" src="/static/img/1.png" /> 
           
          
      
      <br>
            <span style="font-size:10px">{{item.title}}</span><br>
            <span style="color:red;font-size:9px">￥{{item.price}} </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <span style="font-size:9px"><i class="el-icon-user-solid" ></i>{{item.num}}</span>
        </p>
              <!-- <p class="tu">
            <img class="logo" src="/static/img/2.png" /> 
           
          
      
      <br>
            <span style="font-size:10px">想学React.JS不用翻教材 百度大牛</span><br>
     
            <span style="font-size:10px"> 带你结合实践学习</span><br>
            <span style="color:red;font-size:9px">￥234.00 </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <span style="font-size:9px"><i class="el-icon-user-solid" ></i>1234</span>
        </p>
              <p class="tu">
            <img class="logo" src="/static/img/3.png" /> 
           
          
      
      <br>
            <span style="font-size:10px">想学React.JS不用翻教材 百度大牛</span><br>
     
            <span style="font-size:10px"> 带你结合实践学习</span><br>
            <span style="color:red;font-size:9px">￥234.00 </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <span style="font-size:9px"><i class="el-icon-user-solid" ></i>1234</span>
        </p>
              <p class="tu">
            <img class="logo" src="/static/img/4.png" /> 
           
          
      
      <br>
            <span style="font-size:10px">想学React.JS不用翻教材 百度大牛</span><br>
     
            <span style="font-size:10px"> 带你结合实践学习</span><br>
            <span style="color:red;font-size:9px">￥234.00 </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <span style="font-size:9px"><i class="el-icon-user-solid" ></i>1234</span>
        </p> -->
              
            </el-tab-pane>

    <!--  我的收藏-->
    <el-tab-pane label="我的收藏" name="first">







         <el-tabs v-model="activeName" @tab-click="handleClick">
           <p class="tu">
            <img class="logo" src="/static/img/5.png" /> 

            
        </p>
        <p class="tu">
             <span style="font-size:10px">想学React.JS不用翻教材 百度大牛</span><br>
     
            <span style="font-size:10px"> 带你结合实践学习</span><br>
            <span style="color:red;font-size:9px">￥234.00 </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <span style="font-size:9px"><i class="el-icon-user-solid" ></i>1234</span>
           </p>

            <el-tab-pane label="全部" name="first">
              
        
           
            </el-tab-pane>
            
          </el-tabs>
          <br><br><br><br><br><br>
          <p style="font-size:10px">推荐课程</p><br>
         
        <p class="tu" v-for="item in table2data" :key="item.id">
            <img class="logo" src="/static/img/1.png" /> 
           
          
      
      <br>
            <span style="font-size:10px">{{item.title}}</span><br>
            <span style="color:red;font-size:9px">￥{{item.price}} </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <span style="font-size:9px"><i class="el-icon-user-solid" ></i>{{item.num}}</span>
        </p>
        <!-- <p class="tu">
            <img class="logo" src="/static/img/2.png" /> 
           
          
      
      <br>
            <span style="font-size:10px">想学React.JS不用翻教材 百度大牛</span><br>
     
            <span style="font-size:10px"> 带你结合实践学习</span><br>
            <span style="color:red;font-size:9px">￥234.00 </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <span style="font-size:9px"><i class="el-icon-user-solid" ></i>1234</span>
        </p>
              <p class="tu">
            <img class="logo" src="/static/img/3.png" /> 
           
          
      
      <br>
            <span style="font-size:10px">想学React.JS不用翻教材 百度大牛</span><br>
     
            <span style="font-size:10px"> 带你结合实践学习</span><br>
            <span style="color:red;font-size:9px">￥234.00 </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <span style="font-size:9px"><i class="el-icon-user-solid" ></i>1234</span>
        </p>
              <p class="tu">
            <img class="logo" src="/static/img/4.png" /> 
           
          
      
      <br>
            <span style="font-size:10px">想学React.JS不用翻教材 百度大牛</span><br>
     
            <span style="font-size:10px"> 带你结合实践学习</span><br>
            <span style="color:red;font-size:9px">￥234.00 </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <span style="font-size:9px"><i class="el-icon-user-solid" ></i>1234</span>
        </p> -->
              


            </el-tab-pane>



    <!--  我的订单 -->
    <el-tab-pane label="我的订单">

        <el-tabs type="border-card">
        <el-tab-pane label="订单">
                 <el-tabs v-model="activeName" @tab-click="handleClick">
                    <el-tab-pane label="全部" name="first">
                          <p class="tu">
                            <img class="logo" src="/static/img/5.png" /> 

            
                          </p>
                          <p class="tu">
                             <span style="color:red;font-size:9px"><b>￥299.00</b> </span><br>
                          <span style="font-size:10px"><b>领略Rust之美，挑战双高语音</b></span><br>
                  
                          <span style="font-size:10px"> 带你以最高效的学习方式快速入门双高（高性能&高可靠）语言Rust</span><br>
                        
                          <span style="font-size:9px">2020-12-12 &nbsp; &nbsp; 12:00</span>
                        </p>

                    </el-tab-pane>
                    <el-tab-pane label="待支付" name="second">
                    
                    </el-tab-pane>
                    <el-tab-pane label="支付成功" name="third">
                      <p class="tu">
                            <img class="logo" src="/static/img/5.png" /> 

            
                          </p>
                          <p class="tu">
                             <span style="color:red;font-size:9px"><b>￥299.00</b> </span><br>
                          <span style="font-size:10px"><b>领略Rust之美，挑战双高语音</b></span><br>
                  
                          <span style="font-size:10px"> 带你以最高效的学习方式快速入门双高（高性能&高可靠）语言Rust</span><br>
                        
                          <span style="font-size:9px">2020-12-12 &nbsp; &nbsp; 12:00</span>
                        </p>
                    </el-tab-pane>
                    <el-tab-pane label="已关闭" name="four">
                    
                    </el-tab-pane>
                 </el-tabs>
        </el-tab-pane>
        <el-tab-pane label="余额">
          <div class="yuee">
            <div class="zhifu">
                  <div class="yue"><p style="color:white">当前余额</p><br><span style="color:white;font-size:25px">￥0.00</span></div>
                <div class="chongzhi">
               <el-button round style="color:red"><b>立即充值</b></el-button><br>
              
                </div>
                <div class="chongzhi">
                   <span style="color:white;font-size:9px">充值余额不可提现，仅限用于本平台课程消费</span>
                </div>
            </div>
        

          </div>
        </el-tab-pane>
        <el-tab-pane label="消费记录">
              <el-tabs v-model="activeName" @tab-click="handleClick">
                    <el-tab-pane label="全部" name="first">
                          <p class="tu">
                            <img class="logo" src="/static/img/5.png" /> 

            
                          </p>
                          <p class="tu">
                             <span style="color:red;font-size:9px"><b>￥299.00</b> </span><br>
                          <span style="font-size:10px"><b>领略Rust之美，挑战双高语音</b></span><br>
                  
                          <span style="font-size:10px"> 带你以最高效的学习方式快速入门双高（高性能&高可靠）语言Rust</span><br>
                        
                          <span style="font-size:9px">2020-12-12 &nbsp; &nbsp; 12:00</span>
                        </p>
                    </el-tab-pane>
              </el-tabs>


        </el-tab-pane>
       
       </el-tabs>




    </el-tab-pane>
        <!--  我的文章 -->
    <el-tab-pane label="我的文章">
         <el-tabs v-model="activeName" @tab-click="handleClick"><el-button @click="write()" type="danger" style="float:right">写文章</el-button><br><br><br>
            <el-tab-pane label="全部" name="first">
                <div class="article" v-for="item in tabledata" :key="item.id">
               <p class="tu2">
            <img class="logo" src="/static/img/6.png" /> 

               </p>
               <p class="tu1">
                            
                          <span style="font-size:10px"><b>{{item.title}}</b></span><br>
                          <!-- <span style="font-size:10px"><b>TiKV高性能追踪的实现解析</b></span><br> -->
                          <span style="font-size:9px">浏览{{item.liulan}} &nbsp; &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;评论{{item.discuss}} &nbsp; &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;{{item.date}}</span>
              </p>
                </div>
            </el-tab-pane>
         </el-tabs>
    </el-tab-pane>
        <!--  我的考试 -->
    <el-tab-pane label="我的考试">

         <el-tabs v-model="activeName" @tab-click="handleClick">
            <el-tab-pane label="全部" name="first">
                <div class="article" v-for="item in table1data" :key="item.id">
               <p class="tu2">
            <img class="logo" src="/static/img/6.png" /> 

               </p>
               <p class="tu1">                           
                          <span style="font-size:10px"><b>{{item.title}}}</b></span><br>
                          <span style="font-size:9px">考试分数{{item.grade}} &nbsp; &nbsp; &nbsp;  &nbsp;&nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;通过 &nbsp; &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;2020-12-12  12:00</span>
              </p>
                </div>
                            
            </el-tab-pane>
         </el-tabs>

    </el-tab-pane>
  </el-tabs>
            

    
  </div>
    
</div> 
</template>
<style>
  
  .da{
      background-color:white;
      height: 800px;
      width: 100%;
  }
  .header{
      background-color: rgb(14, 41, 92);
      height: 100px;
      width: 100%;
  }
  .zuo{
      background-color:white;
      height: 700px;
      width: 100%;
      float: left;
  }
  .photo{
  
      padding-left: 100px;
      padding-top: 45px;
      float: left;
  }
  .edit{
  
      padding-left: 10px;
      padding-top: 45px;
      float: left;
      color: white;
  }
  .kecheng{
     
      float: left;
      color: white;
  }
  .logo{
   
    margin-top: -10px;
}
.tu{
  float: left;
  padding-right: 15px;
}
.tu1{
  float: left;
  width: 880px;
  padding-left: 45px;
}
.tu2{
  float: left;
  width: 60px;
  padding-left: 30px;
}
.article{
  float: left;
  margin-top: 20px;
}
.zhifu{
  background: -webkit-linear-gradient(left,rgba(245, 97, 11, 0.863),rgba(243, 62, 7, 0.932),rgb(247, 42, 6)) no-repeat;
  height: 115px;
  width: 100%;
}
.yue{
  float: left;
  height: 90px;
  width: 120px;
  padding-top: 15px;
  padding-left: 25px;
}
.yuee{
  height: 300px;
  width: 100%;
}
.chongzhi{
  float: right;
  padding-top: 25px;
  padding-right: 30px;
  padding-left: 600px;
  margin-bottom: -20px;
}
</style>
<style>

</style>
<script>
  export default {
    data() {
      return {
        tabPosition: 'left',
        activeName: 'first',
        tabledata:[],
        table1data:[],
        table2data:[]
      };
         
    },
  mounted() 
  {
    this.GetData();
    this.GetData1();
    this.GetData2();
  },
    methods: {
      write(){
        console.log("写文章");
        this.$router.push('/write')
      },
      shouye(){
        console.log("首页");
        this.$router.push('/start');
      },
       GetData2(){
          this.$axios({
        
          url:"http://localhost:53590/api/Shops/Recommend",
          methods: "get",
        }).then((res) => {
          
          this.table2data = res.data.data;
          //this.Statuss=res.data.Statuss;
          //alert(JSON.stringify(this.tabledata))
        });
      },
      GetData1(){
          this.$axios({
        
          url:"http://localhost:53590/api/Shops/Exam",
          methods: "get",
        }).then((res) => {
          
          this.table1data = res.data.data;
          //this.Statuss=res.data.Statuss;
          //alert(JSON.stringify(this.tabledata))
        });
      },
      GetData()
     {
        
      this.$axios({
      
        url:"http://localhost:53590/api/Shops/Article",
        methods: "get",
      }).then((res) => {
        
        this.tabledata = res.data.data;
        //this.Statuss=res.data.Statuss;
        //alert(JSON.stringify(this.tabledata))
      });
    },
      handleClick(tab, event) {
        console.log(tab, event);
      }
    }
    
  };
</script>