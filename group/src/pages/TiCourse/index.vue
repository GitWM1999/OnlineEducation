<template>
    
<div class="da">

    <div class="shang">
        <p>
            <img class="logo" src="/static/img/logoti.png"  />
            &#12288;
            <span style="font-size:20px">真实项目实战演练</span>   
        </p>
        
        <p style="float:right;"> 
            <el-input class="query"  placeholder="搜索课程名称"></el-input>
            <el-button type="text" class="sou" icon="el-icon-search"></el-button> 
       </p>
       <br>
       <br> 
       <br>   
       <span style="font-weight: 700;font-size:20px">方向：</span>

       <div  class="aan" v-for="item in tabledata" :key="item.typeId" style="display: inline-block;">
            <el-button type="text" class="an">{{item.typeName}}</el-button>
       </div>
            <!-- <el-button type="text" class="an">网站课程</el-button>
            <el-button type="text" class="an">传媒课程</el-button>
            <el-button type="text" class="an">全栈课程</el-button>
            <el-button type="text" class="an">大数据课程</el-button>
            <el-button type="text" class="an">云计算课程</el-button>
            <el-button type="text" class="an">物联网课程</el-button> -->
    
        <p><span style="font-weight: 700;font-size:20px">分类：</span>
            <el-button type="text" class="an1">Vue.js</el-button>
            <el-button type="text" class="an1">Typescript</el-button>
            <el-button type="text" class="an1">React.JS</el-button>
            <el-button type="text" class="an1">HTML/CSS</el-button>
            <el-button type="text" class="an1">JavaScript</el-button>
            <el-button type="text" class="an1">Angular</el-button>
            <el-button type="text" class="an1">Node.js</el-button>
            <el-button type="text" class="an1">jQuery</el-button>
            <el-button type="text" class="an1">Bootstrap</el-button>
            <el-button type="text" class="an1">Sass/Less</el-button>
            <el-button type="text" class="an1">WebApp</el-button>
            <el-button type="text" class="an1">小程序前端工具</el-button>
            <el-button type="text" class="an1">CSS</el-button>
            <el-button type="text" class="an1">Html5</el-button>
            <el-button type="text" class="an1">CSS3</el-button>
       </p>
            <p><span style="font-weight: 700;font-size:20px">模式：</span>
            <el-button type="text" class="an1">录播课</el-button>
            <el-button type="text" class="an1">直播课</el-button>            
       </p>

    </div>
    <div class="zhong">

         <el-tabs v-model="activeName" @tab-click="handleClick">
         <el-tab-pane label="录播" name="first">
             <p class="tua">
                <img class="lutu" src="/static/img/class.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="color:red;font-weight:700">￥448.00</span>
                 &#12288; &#12288; &#12288; &#12288; &#12288; &#12288;
                <el-button type="text" class="an2" icon="el-icon-star-on"></el-button>
                <el-button type="text" class="an3" icon="el-icon-shopping-cart-full"></el-button>
                <el-button type="text" class="an3">加购物车</el-button>
            </p>
            <p class="tua">
                <img class="lutu" src="/static/img/class.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="color:red;font-weight:700">￥448.00</span>
                 &#12288; &#12288; &#12288; &#12288; &#12288; &#12288;
                <el-button type="text" class="an2" icon="el-icon-star-on"></el-button>
                <el-button type="text" class="an3" icon="el-icon-shopping-cart-full"></el-button>
                <el-button type="text" class="an3">加购物车</el-button>
            </p>
                    <p class="tua">
                <img class="lutu" src="/static/img/class.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="color:red;font-weight:700">￥448.00</span>
                 &#12288; &#12288; &#12288; &#12288; &#12288; &#12288;
                <el-button type="text" class="an2" icon="el-icon-star-on"></el-button>
                <el-button type="text" class="an3" icon="el-icon-shopping-cart-full"></el-button>
                <el-button type="text" class="an3">加购物车</el-button>
            </p>
                    <p class="tua">
                <img class="lutu" src="/static/img/class.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="color:red;font-weight:700">￥448.00</span>
                 &#12288; &#12288; &#12288; &#12288; &#12288; &#12288;
                <el-button type="text" class="an2" icon="el-icon-star-on"></el-button>
                <el-button type="text" class="an3" icon="el-icon-shopping-cart-full"></el-button>
                <el-button type="text" class="an3">加购物车</el-button>
            </p>
                     <p class="tua">
                <img class="lutu" src="/static/img/class.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="color:red;font-weight:700">￥448.00</span>
                 &#12288; &#12288; &#12288; &#12288; &#12288; &#12288;
                <el-button type="text" class="an2" icon="el-icon-star-on"></el-button>
                <el-button type="text" class="an3" icon="el-icon-shopping-cart-full"></el-button>
                <el-button type="text" class="an3">加购物车</el-button>
            </p>
            <p class="tua">
                <img class="lutu" src="/static/img/class.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="color:red;font-weight:700">￥448.00</span>
                 &#12288; &#12288; &#12288; &#12288; &#12288; &#12288;
                <el-button type="text" class="an2" icon="el-icon-star-on"></el-button>
                <el-button type="text" class="an3" icon="el-icon-shopping-cart-full"></el-button>
                <el-button type="text" class="an3">加购物车</el-button>
            </p>
                    <p class="tua">
                <img class="lutu" src="/static/img/class.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="color:red;font-weight:700">￥448.00</span>
                 &#12288; &#12288; &#12288; &#12288; &#12288; &#12288;
                <el-button type="text" class="an2" icon="el-icon-star-on"></el-button>
                <el-button type="text" class="an3" icon="el-icon-shopping-cart-full"></el-button>
                <el-button type="text" class="an3">加购物车</el-button>
            </p>
                    <p class="tua">
                <img class="lutu" src="/static/img/class.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="color:red;font-weight:700">￥448.00</span>
                 &#12288; &#12288; &#12288; &#12288; &#12288; &#12288;
                <el-button type="text" class="an2" icon="el-icon-star-on"></el-button>
                <el-button type="text" class="an3" icon="el-icon-shopping-cart-full"></el-button>
                <el-button type="text" class="an3">加购物车</el-button>
            </p>
                     <p class="tua">
                <img class="lutu" src="/static/img/class.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="color:red;font-weight:700">￥448.00</span>
                 &#12288; &#12288; &#12288; &#12288; &#12288; &#12288;
                <el-button type="text" class="an2" icon="el-icon-star-on"></el-button>
                <el-button type="text" class="an3" icon="el-icon-shopping-cart-full"></el-button>
                <el-button type="text" class="an3">加购物车</el-button>
            </p>
            <p class="tua">
                <img class="lutu" src="/static/img/class.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="color:red;font-weight:700">￥448.00</span>
                 &#12288; &#12288; &#12288; &#12288; &#12288; &#12288;
                <el-button type="text" class="an2" icon="el-icon-star-on"></el-button>
                <el-button type="text" class="an3" icon="el-icon-shopping-cart-full"></el-button>
                <el-button type="text" class="an3">加购物车</el-button>
            </p>
                    <p class="tua">
                <img class="lutu" src="/static/img/class.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="color:red;font-weight:700">￥448.00</span>
                 &#12288; &#12288; &#12288; &#12288; &#12288; &#12288;
                <el-button type="text" class="an2" icon="el-icon-star-on"></el-button>
                <el-button type="text" class="an3" icon="el-icon-shopping-cart-full"></el-button>
                <el-button type="text" class="an3">加购物车</el-button>
            </p>
                    <p class="tua">
                <img class="lutu" src="/static/img/class.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="color:red;font-weight:700">￥448.00</span>
                 &#12288; &#12288; &#12288; &#12288; &#12288; &#12288;
                <el-button type="text" class="an2" icon="el-icon-star-on"></el-button>
                <el-button type="text" class="an3" icon="el-icon-shopping-cart-full"></el-button>
                <el-button type="text" class="an3">加购物车</el-button>
            </p>
                     <p class="tua">
                <img class="lutu" src="/static/img/class.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="color:red;font-weight:700">￥448.00</span>
                 &#12288; &#12288; &#12288; &#12288; &#12288; &#12288;
                <el-button type="text" class="an2" icon="el-icon-star-on"></el-button>
                <el-button type="text" class="an3" icon="el-icon-shopping-cart-full"></el-button>
                <el-button type="text" class="an3">加购物车</el-button>
            </p>
            <p class="tua">
                <img class="lutu" src="/static/img/class.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="color:red;font-weight:700">￥448.00</span>
                 &#12288; &#12288; &#12288; &#12288; &#12288; &#12288;
                <el-button type="text" class="an2" icon="el-icon-star-on"></el-button>
                <el-button type="text" class="an3" icon="el-icon-shopping-cart-full"></el-button>
                <el-button type="text" class="an3">加购物车</el-button>
            </p>
                    <p class="tua">
                <img class="lutu" src="/static/img/class.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="color:red;font-weight:700">￥448.00</span>
                 &#12288; &#12288; &#12288; &#12288; &#12288; &#12288;
                <el-button type="text" class="an2" icon="el-icon-star-on"></el-button>
                <el-button type="text" class="an3" icon="el-icon-shopping-cart-full"></el-button>
                <el-button type="text" class="an3">加购物车</el-button>
            </p>
                    <p class="tua">
                <img class="lutu" src="/static/img/class.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="color:red;font-weight:700">￥448.00</span>
                 &#12288; &#12288; &#12288; &#12288; &#12288; &#12288;
                <el-button type="text" class="an2" icon="el-icon-star-on"></el-button>
                <el-button type="text" class="an3" icon="el-icon-shopping-cart-full"></el-button>
                <el-button type="text" class="an3">加购物车</el-button>
            </p>

         </el-tab-pane>
         <el-tab-pane label="直播" name="second">
            <p class="tua">
                <img class="lutu" src="/static/img/ren.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="font-size:16px">开播时间：2012-12-12 12:00
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a>预约</a>
                </span>
                <br>
                <span style="color:red;font-weight:700">￥300.00</span>
            </p>
                   <p class="tua">
                <img class="lutu" src="/static/img/ren2.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="font-size:16px">开播时间：2012-12-12 12:00
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a>预约</a>
                </span>
                <br>
                <span style="color:red;font-weight:700">￥300.00</span>
            </p>
                        <p class="tua">
                <img class="lutu" src="/static/img/ren.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="font-size:16px">开播时间：2012-12-12 12:00
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a>预约</a>
                </span>
                <br>
                <span style="color:red;font-weight:700">￥300.00</span>
            </p>
                   <p class="tua">
                <img class="lutu" src="/static/img/ren2.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="font-size:16px">开播时间：2012-12-12 12:00
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a>预约</a>
                </span>
                <br>
                <span style="color:red;font-weight:700">￥300.00</span>
            </p>
                        <p class="tua">
                <img class="lutu" src="/static/img/ren.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="font-size:16px">开播时间：2012-12-12 12:00
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a>预约</a>
                </span>
                <br>
                <span style="color:red;font-weight:700">￥300.00</span>
            </p>
                   <p class="tua">
                <img class="lutu" src="/static/img/ren2.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="font-size:16px">开播时间：2012-12-12 12:00
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a>预约</a>
                </span>
                <br>
                <span style="color:red;font-weight:700">￥300.00</span>
            </p>
                        <p class="tua">
                <img class="lutu" src="/static/img/ren.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="font-size:16px">开播时间：2012-12-12 12:00
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a>预约</a>
                </span>
                <br>
                <span style="color:red;font-weight:700">￥300.00</span>
            </p>
                   <p class="tua">
                <img class="lutu" src="/static/img/ren2.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="font-size:16px">开播时间：2012-12-12 12:00
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a>预约</a>
                </span>
                <br>
                <span style="color:red;font-weight:700">￥300.00</span>
            </p>
                        <p class="tua">
                <img class="lutu" src="/static/img/ren.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="font-size:16px">开播时间：2012-12-12 12:00
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a>预约</a>
                </span>
                <br>
                <span style="color:red;font-weight:700">￥300.00</span>
            </p>
                   <p class="tua">
                <img class="lutu" src="/static/img/ren2.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="font-size:16px">开播时间：2012-12-12 12:00
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a>预约</a>
                </span>
                <br>
                <span style="color:red;font-weight:700">￥300.00</span>
            </p>
                        <p class="tua">
                <img class="lutu" src="/static/img/ren.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="font-size:16px">开播时间：2012-12-12 12:00
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a>预约</a>
                </span>
                <br>
                <span style="color:red;font-weight:700">￥300.00</span>
            </p>
                   <p class="tua">
                <img class="lutu" src="/static/img/ren2.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="font-size:16px">开播时间：2012-12-12 12:00
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a>预约</a>
                </span>
                <br>
                <span style="color:red;font-weight:700">￥300.00</span>
            </p>
                        <p class="tua">
                <img class="lutu" src="/static/img/ren.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="font-size:16px">开播时间：2012-12-12 12:00
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a>预约</a>
                </span>
                <br>
                <span style="color:red;font-weight:700">￥300.00</span>
            </p>
                   <p class="tua">
                <img class="lutu" src="/static/img/ren2.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="font-size:16px">开播时间：2012-12-12 12:00
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a>预约</a>
                </span>
                <br>
                <span style="color:red;font-weight:700">￥300.00</span>
            </p>
                        <p class="tua">
                <img class="lutu" src="/static/img/ren.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="font-size:16px">开播时间：2012-12-12 12:00
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a>预约</a>
                </span>
                <br>
                <span style="color:red;font-weight:700">￥300.00</span>
            </p>
                   <p class="tua">
                <img class="lutu" src="/static/img/ren2.png"  />
                <br>
                <span style="font-size:16px">想学React.JS不用翻教材 百度大牛带你结合</span>
                <br>
                <span style="font-size:16px">实践学习</span>
                <br>
                <br>
                <span style="font-size:16px">已有1234人学习</span>
                <br>
                <span style="font-size:16px">开播时间：2012-12-12 12:00
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a>预约</a>
                </span>
                <br>
                <span style="color:red;font-weight:700">￥300.00</span>
            </p>
         </el-tab-pane>
         </el-tabs>   
    </div>

<div class="xia">
        <br>
        <span class="guan">关于我们</span>
        <span class="guan">联系我们</span>
        <span class="guan">讲师招募</span>
        <span class="guan">帮助中心</span>
        <span class="guan">意见反馈</span>
        <span class="guan">就业服务</span>
        <br>
        <br>
        <br>
        <span class="guan">邮编：100193&nbsp;&nbsp;&nbsp;&nbsp;电话：400-008-0987&nbsp;&nbsp;&nbsp;&nbsp;业务及合作：bjebin@163.com</span> 
        <br>
        
        <p  class="wei">
            <span>&nbsp;</span>
            <img  src="/static/img/wei.png"  />
            <br>    
            <br> 
            <span class="guan1">微信公众号</span>
        </p>
        <p class="wei">
            <span>&nbsp;</span>
            
            <img   src="/static/img/xing.png"  />
            <br>  
            <br> 
            <span class="guan1">收藏本站</span>
        </p>
         
          
        <br>
        <br>
        <span class="guan">八维教育&nbsp;&nbsp;&nbsp;&nbsp;京公网安备11010802031438</span> 
        <br>
        <br>
        <br>
        
</div>

</div>

</template>

<script>
  export default {
    data() 
    {
      return {

        activeName: 'first',
        tabledata:[]
      };
    },
    mounted() 
  {
    this.GetData();
   
  },
    methods: 
    {
    
    GetData()
     {
        
      this.$axios({
      
        url:"/api/Order/GetClassTypeData",
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

<style>

.sou{
   font-size: 15px;
   width: 50px;
   color: white;
   margin-right:50px;
   background-color:gray;   
}
.query{
    
    width: 300px;
    height: 20px;
    margin-right:-5px;
    
}
.shang{
    
    background-color:gainsboro;   
    margin-left: 30px;
}
.an{
   font-size: 20px;
   color: black;
}
.aan
{
  padding-right: 20px;
}
.an1{
   font-size: 15px;
   color: black;
   
}
.an2{
   font-size: 17px;
   color: black;
   
}
.an3{
   font-size: 17px;
   color: red;
   
}
.zhong{
    
    margin-left: 30px;
}
.tua{
  float: left;
  padding-right: 50px;
  padding-top:25px;
}
.xia{
    
    background-color:grey;   
    margin-left: 30px;
}
.guan{
     
    margin-left: 30px;
    color: white;
   
}
.guan1{
     
    color: white;
}

.wei{
     float: right;
      margin-right: 50px;
      

}
</style>