<template>
    <div>
        <h1>{{msg}}</h1>
        <p v-html="hello"></p>
        <p v-text="hello"></p>
        <span v-bind:class="ha">我点击事件</span>
  <div>      
   <template v-if="show">
      <span>我是为true看到的</span>
   </template>
   <template v-else>
         <span>我是false看到的</span>
   </template>
  </div>
   <div class="list">
      <ul>
          <li v-for="item in user" :key="item">
              <span>{{ item.name }}</span>
              <span>{{ item.age }}</span>
          </li>
      </ul>
   </div>
</div>
</template>

<script>
export default {
  name: 'index',
  data () {
    return {
      msg: 'Welcome to Your Vue.js App',
      hello:'<p>My name is LIMiao</p>',
      ha:"ha1",
      show:true,
      user:[
          {
              id:0,
              name:'iwen',
              age:"20"
          },
          {
              id:2,
              name:'ice',
              age:"18"
          },
          {
              id:2,
              name:'ime',
              age:"20"
          }
      ]
    }
  }
}
</script>

<style scoped>
.ha{

    color:red;
}
</style>




