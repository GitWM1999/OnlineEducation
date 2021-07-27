<template>
  <div>
    <div id="title">我是第一个子组件</div>
    <div>我接受到的父组件的消息是：{{msg}}</div>
    我要给第二个兄弟发信息，内容是:
    <input type="text" v-model="to" />
    <button @click="toBrother">点我给兄弟传值</button>
  </div>
</template>

<script>
export default {
  props: {
    msg: ""
  },
  data(){
      return{
          to:"哈喽老二"
      };
  },
  methods:{
      toBrother(){
          this.bus.$emit("toBrother",this.to);
      }
  }
};
</script>