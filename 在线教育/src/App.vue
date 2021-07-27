<template>

  <div id="app">
<!--    <img src="./assets/logo.png">-->
    <!--    <HelloWorld/>-->
<!--    <MyComponent></MyComponent>-->
<p>

<router-link class="ai" to="/start">八维教育首页</router-link>

<!-- <img class="logo"  src="/static/img/logo.png" to="/start" /> -->

<router-link  class="an" to="/recorded">免费课程</router-link>

<el-button type="text" class="an">体系课程</el-button>

<el-button type="text" class="an">在线测评</el-button>

<el-button type="text" class="an">学习社区</el-button>

<el-input class="query" placeholder="请输入关键字"></el-input>

<el-button type="text" class="an">我的收藏</el-button>

<el-button type="text" class="an" icon="el-icon-shopping-cart-full"></el-button>

 <router-link class="ai" to="/login">登录</router-link>

<!-- <el-button type="text" class="an" to="/login">登录   /</el-button> -->

<el-button type="text" class="register">注册</el-button>
</p>

<router-view></router-view>

  </div>

</template>

<script>

import login from "./components/login";

export default {
  name: 'App',
  components: {
    // HelloWorld
    login
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
.an{
   font-size: 21px;
   color: black;
   margin-left: 50px;
   
}
.register{
   font-size: 21px;
   color: black;
  
}
.logo{
    margin-left: 10px;
    margin-top: -10px;
}
.query{
    margin-left: 30px;
    width: 240px;
    height: 42px;
    margin-top: -5px;
    border: 1px black solid;
}
.ai{
   font-size: 21px;
   color: black;
   margin-left: 50px;
}
</style>
