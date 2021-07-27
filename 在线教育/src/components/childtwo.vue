<template>
  <div>
    <div id="title">我是第二个子组件</div>
    <div>我要发送给父组件的值：{{msg}}</div>
    <button @click="toParent">向父组件发送信息</button>

    <div>我得到的兄弟组件信息士:{{get}}</div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      msg: "我是第二组件，我要给父组件传值",
      get:""
    };
  },
  methods: {
    toParent() {
      this.$emit("toParent", this.msg);
    }
  },
  beforeCreate(){
      this.bus.$on("toBrother",msg=>{
          this.get=msg;
      });
  }
};
</script>