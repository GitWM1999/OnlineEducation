<template>
  <div class="login-container">
    <el-form ref="form" :model="form" label-width="80px" class="login-form">
      <h2 class="login-title">管理系统</h2>
      <el-form-item label="用户名">
        <el-input v-model="form.username"></el-input>
      </el-form-item>
      <el-form-item label="密码">
        <el-input v-model="form.password" type="password"></el-input>
      </el-form-item>
      <el-form-item label="验证码">
        <el-input v-model="form.verification"></el-input>
      </el-form-item>
      <div class="s-canvas">
            <canvas
              style="height: 40px;"
              @click="btn2()"
              id="s-canvas"
              :width="contentWidth"
              :height="contentHeight"
            ></canvas>
          </div>
      <el-form-item>
        <el-button type="primary" @click="onSubmit">登录</el-button>
      </el-form-item>
    </el-form>
  </div>
  
</template>
  <script>

export default {
  data() {
    return {
      form: {
        username: "",
        password: "",
        verification:""
      },
      user:{
        Id:0,
        UserName:"",
        Pwd:""
      }
    };
  },
  props: {
    identifyCode: {
      type: String,
      default: ""
    },
    fontSizeMin: {
      type: Number,
      default: 25
    },
    fontSizeMax: {
      type: Number,
      default: 30
    },
    backgroundColorMin: {
      type: Number,
      default: 255
    },
    backgroundColorMax: {
      type: Number,
      default: 255
    },
    colorMin: {
      type: Number,
      default: 0
    },
    colorMax: {
      type: Number,
      default: 160
    },
    lineColorMin: {
      type: Number,
      default: 100
    },
    lineColorMax: {
      type: Number,
      default: 255
    },
    dotColorMin: {
      type: Number,
      default: 0
    },
    dotColorMax: {
      type: Number,
      default: 255
    },
    contentWidth: {
      type: Number,
      default: 112
    },
    contentHeight: {
      type: Number,
      default: 31
    }
  },
  created: function() {
    this.btn2();
  },
  methods: {
    onSubmit() {
       if(this.form.username==""){

         this.$message.error("账号不能为空");
         return false;
       }
       else if(this.form.password==""){
         this.$message.error("密码不能为空");
       }
       else if(this.form.verification==""){
         this.$message.error("验证码不能为空");
       }
       else if(this.form.verification!=this.identifyCode){
         this.$message.error("验证码错误");
       }else{
         this.user.UserName=this.form.username;
         this.user.Pwd=this.form.password;
         alert(JSON.stringify(this.user));
         this.$axios({
           url:"http://10.3.181.32:53590/api/Login/login",
           method:"post",
           params:this.user
         }).then((res)=>{
           if(res.data>0){
             this.$message({
               type:"success",
               message:"登录成功",
               align:"center"
             }
             );
               this.$router.push('/main');
           }
         })
       }
       
       
    },
     btn2() {
      var identifyCode = "";
      //设置长度，这里看需求，我这里设置了4
      var codeLength = 4;

      //设置随机字符
      var random = new Array(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);

      //循环codeLength 我设置的4就是循环4次
      for (var i = 0; i < codeLength; i++) {
        //设置随机数范围,这设置为0 ~ 36
        var index = Math.floor(Math.random() * 9);

        //字符串拼接 将每次随机的字符 进行拼接
        identifyCode += random[index];
      }
      //将拼接好的字符串赋值给展示的code
      this.identifyCode = identifyCode;
    },
    // 生成一个随机数
    randomNum(min, max) {
      return Math.floor(Math.random() * (max - min) + min);
    },
    // 生成一个随机的颜色
    randomColor(min, max) {
      let r = this.randomNum(min, max);
      let g = this.randomNum(min, max);
      let b = this.randomNum(min, max);
      return "rgb(" + r + "," + g + "," + b + ")";
    },
    drawPic() {
      let canvas = document.getElementById("s-canvas");
      let ctx = canvas.getContext("2d");
      ctx.textBaseline = "bottom";
      // 绘制背景
      ctx.fillStyle = this.randomColor(
        this.backgroundColorMin,
        this.backgroundColorMax
      );
      ctx.fillRect(0, 0, this.contentWidth, this.contentHeight);
      // 绘制文字
      for (let i = 0; i < this.identifyCode.length; i++) {
        this.drawText(ctx, this.identifyCode[i], i);
      }
      this.drawLine(ctx);
      this.drawDot(ctx);
    },
    drawText(ctx, txt, i) {
      ctx.fillStyle = this.randomColor(this.colorMin, this.colorMax);
      ctx.font =
        this.randomNum(this.fontSizeMin, this.fontSizeMax) + "px SimHei";
      let x = (i + 1) * (this.contentWidth / (this.identifyCode.length + 1));
      let y = this.randomNum(this.fontSizeMax, this.contentHeight - 5);
      var deg = this.randomNum(-45, 45);
      // 修改坐标原点和旋转角度
      ctx.translate(x, y);
      ctx.rotate((deg * Math.PI) / 180);
      ctx.fillText(txt, 0, 0);
      // 恢复坐标原点和旋转角度
      ctx.rotate((-deg * Math.PI) / 180);
      ctx.translate(-x, -y);
    },
    drawLine(ctx) {
      // 绘制干扰线
      for (let i = 0; i < 5; i++) {
        ctx.strokeStyle = this.randomColor(
          this.lineColorMin,
          this.lineColorMax
        );
        ctx.beginPath();
        ctx.moveTo(
          this.randomNum(0, this.contentWidth),
          this.randomNum(0, this.contentHeight)
        );
        ctx.lineTo(
          this.randomNum(0, this.contentWidth),
          this.randomNum(0, this.contentHeight)
        );
        ctx.stroke();
      }
    },
    drawDot(ctx) {
      // 绘制干扰点
      for (let i = 0; i < 80; i++) {
        ctx.fillStyle = this.randomColor(0, 255);
        ctx.beginPath();
        ctx.arc(
          this.randomNum(0, this.contentWidth),
          this.randomNum(0, this.contentHeight),
          1,
          0,
          2 * Math.PI
        );
        ctx.fill();
      }
    }
  },
  watch: {
    identifyCode() {
      this.drawPic();
    }
  },
  mounted() {
    this.drawPic();
  }
};
</script>

<style acoped>
.login-form {
  width: 350px;
  margin: 160px auto; /* 上下间距160px，左右自动居中*/
  background-color: rgb(255, 255, 255, 0.8); /* 透明背景色 */
  padding: 30px;
  border-radius: 20px; /* 圆角 */
}

/* 背景 */
.login-container {
  position: absolute;
  width: 100%;
  height: 100%;
}

/* 标题 */
.login-title {
  color: #303133;
  text-align: center;
}
.s-canvas{
   text-align: center;
}
</style> -->