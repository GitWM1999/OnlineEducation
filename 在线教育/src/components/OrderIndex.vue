<template>
    <div>
      <el-header style="text-align: right; font-size: 12px">
      <h3>八维在线教育教师端</h3>
      <el-dropdown>
        <i class="el-icon-setting" style="margin-right: 15px"></i>
        <el-dropdown-menu slot="dropdown">
          <el-dropdown-item>查看</el-dropdown-item>
          <el-dropdown-item>新增</el-dropdown-item>
          <el-dropdown-item>删除</el-dropdown-item>
        </el-dropdown-menu>
      </el-dropdown>
    </el-header> 
<el-container style="height: 800px; border: 1px solid #eee;">
  <el-aside width="200px" style="background-color: #474f57">
    <el-menu :default-active="2"
      class="el-menu-vertical-demo"
      @open="handleOpen"
      @close="handleClose"
      background-color="#474f57"
      text-color="#fff"
      :router='true'
      active-text-color="#ffd04b">
      <!-- <el-submenu index="3">
          <template slot="title"><i class="el-icon-s-marketing"></i>营销</template>
        <el-menu-item-group>
          <template slot="title">秒杀管理</template>
          <el-menu-item index="3-1">秒杀配置</el-menu-item>
          <el-menu-item index="3-2">秒杀商品</el-menu-item>
        </el-menu-item-group>
        <el-menu-item-group>
          <template slot="title">砍价管理</template>
          <el-menu-item index="3-3">秒杀配置</el-menu-item>
          <el-menu-item index="3-4">秒杀商品</el-menu-item>
        </el-menu-item-group>
      </el-submenu>
      <el-submenu index="4"> -->
        <!-- <template slot="title"><i class="el-icon-postcard"></i>订单</template>
        <el-menu-item index="4-1-1">订单管理</el-menu-item>
        <el-menu-item index="4-1-2">订单概述</el-menu-item>
        <el-menu-item index="4-1-3">评价管理</el-menu-item>
        <el-menu-item index="4-1-4">订单配送</el-menu-item>
      </el-submenu> -->
      <!-- <el-submenu index="5">
        <template slot="title"><i class="el-icon-user-solid"></i>团长</template>
        <el-menu-item index="5-1-1">团长管理</el-menu-item>
        <el-menu-item index="5-1-2">团长审核</el-menu-item>
        <el-menu-item index="5-1-3">团长等级</el-menu-item>
        <el-menu-item index="5-1-4">设置</el-menu-item>
        <el-menu-item index="5-1-5">路线</el-menu-item>
      </el-submenu>
       <el-submenu index="6">
        <template slot="title"><i class="el-icon-s-shop"></i>门店</template>
        <el-menu-item index="6-1-1">配置</el-menu-item>
        <el-menu-item index="6-1-2">门店</el-menu-item>
        <el-menu-item index="6-1-3">商品</el-menu-item>
        <el-menu-item index="6-1-4">订单</el-menu-item>
        <el-menu-item index="6-1-5">体现</el-menu-item>
        <el-menu-item index="6-1-6">到店付款</el-menu-item>
      </el-submenu>
      <el-submenu index="7">
        <template slot="title"><i class="el-icon-s-home"></i>仓库</template>
        <el-menu-item index="7-1-1">仓库管理</el-menu-item>
        <el-menu-item index="7-1-2">配送校区</el-menu-item>
        <el-menu-item index="7-1-3">入库管理</el-menu-item>
        <el-menu-item index="7-1-4">出库管理</el-menu-item>
        <el-menu-item index="7-1-5">出库查询</el-menu-item>
        <el-menu-item index="7-1-6">盘点管理</el-menu-item>
        <el-menu-item index="7-1-7">现有库存</el-menu-item>
      </el-submenu>
       <el-submenu index="8">
        <template slot="title"><i class="el-icon-message"></i>分销</template>
        <el-menu-item index="8-1-1">超级会员</el-menu-item>
        <el-menu-item index="8-1-2">代理商</el-menu-item>
        <el-menu-item index="8-1-3">佣金记录</el-menu-item>
        <el-menu-item index="8-1-4">设置</el-menu-item>
      </el-submenu> -->
      <el-submenu v-for="item in data" :key='item.id'  :index="item.index">
        <template slot="title"><i :class="item.icon"></i>{{item.name}}</template>
        <el-menu-item v-for="v in item.children" :key='v.id' :index="v.index">{{v.name}}</el-menu-item>
      </el-submenu>
    </el-menu>
  </el-aside>
  
  <el-container>
    <div></div>
    <router-view />
  </el-container>
</el-container>
    </div>
    
</template>
<style>
  .el-header {
    background-color: #3a8ed3;
    color: #fff;
    line-height: 60px;
  }
  .el-aside {
    color: #333;
  }
  h3{
    float: left;
  }
</style>

<script>

  export default {
    methods: {
      handleOpen(key, keyPath) {
        console.log(key, keyPath);
      },
      handleClose(key, keyPath) {
        console.log(key, keyPath);
      },
      handleSizeChange(val) {
        console.log(`每页 ${val} 条`);
      },
      handleCurrentChange(val) {
        console.log(`当前页: ${val}`);
      }
    },
    data() {   
      return {

        data:[{
          name:"工作台",
          index:"1",
          icon:"el-icon-menu"
        },
        {
           name:"平台配置",
           index:"2",
           children:[
             {
               name:"头部导航",
               index:"/main/platform/article"
             },
             {
               name:"专区管理",
               index:"/main/platform/navigation"
             },
             {
               name:"轮播管理",
               index:"/main/platform/prefecture"
             },
             {
               name:"底部文章",
               index:"/main/platform/slideshow"
             }
           ]

        },
        {
          name:"课程管理",
          index:"3",
          children:[
            {
              name:"课程列表",
              index:"/main/CourseManager/Course"
            },
            {
              name:"课程审核",
              index:"/main/CourseManager/CourseChecks"

            },
            {
              name:"课程分类",
              index:"/main/CourseManager/TypeManager"
            }
          ]
        },
        {
          name:"题库管理",
          index:"4",
          children:[
            {
              name:"题库分类"
            },
            {
              name:"考试列表"
            }
          ]
        },
        {
          name:"讲师管理",
          index:"5"
        },
        {
          name:"学员管理",
          index:"6"
        },
        {
          name:"订单管理",
          index:"7"
        },
        {
          name:"权限管理",
          index:"8"
        }
        ],
        formInline: {
          user: '',
          region: ''
        }
      }    
    },
  };

</script>