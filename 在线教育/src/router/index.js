import Vue from 'vue'
import Router from 'vue-router'
import OrderIndex from '@/components/OrderIndex'
import axios from '@/utils/request'

import api from '@/router/imgURL'

Vue.use(Router)
Vue.prototype.$axios=axios;

Vue.prototype.APIurl=api;

export default new Router({
  routes: [
    {
      path: '/',
      name: '首页',
      redirect:"/main",
      component: OrderIndex

    },
    {
      path: '/main',
      name: 'Main',
      // redirect: '/main/goods/management',
      component: () => import('@/components/OrderIndex.vue'),
      children: [
        {
          path:'/main/CourseManager/Course',
          name:'article',
          component:()=>import('@/pages/CourseManager/Course/index')
        },
        {
          path:'/main/CourseManager/CourseChecks',
          name:'navigation',
          component:()=>import('@/pages/CourseManager/CourseChecks/index')
        },
        {
          path:'/main/CourseManager/TypeManager',
          name:'prefecture',
          component:()=>import('@/pages/CourseManager/TypeManager/TypeManager')
        },
        {
          path:'/main/CourseManager/TypeManager',
          name:'prefecture',
          component:()=>import('@/pages/CourseManager/TypeManager/SedType')
        },
        {
          path:'/main/platform/slideshow',
          name:'slideshow',
          component:()=>import('@/pages/platform/slideshow/index')
        },

        {
          path:'/main/Course/SedType',
          name:'slideshow',
          component:()=>import('@/pages/CourseManager/TypeManager/SedType')
        }
      ]
    }
    
  ]
})
