<template>
    <div class="ArticleDetail">
  <div ref="editor" style="text-align:left">
       
  </div>
</div>
</template>
<script>

  import axios from 'axios';
  import {Loading} from 'element-ui'
  import E from 'wangeditor'
  var editor;

  export default {
    name: "WriteArticle",
    data: function () {
      return {
        Title:'',
        Content:''
      }
    },
    mounted:function(){
      var That = this;
      editor = new E(this.$refs.editor);
      editor.customConfig = {
        onchange:function(html){
          That.Content = html
        },
        uploadImgServer: '/api/UploadImg', // 上传图片到服务器
        uploadFileName : 'Content', //后端使用这个字段获取图片信息
        uploadImgMaxLength : 1 , // 限制一次最多上传 1 张图片
      } 
      editor.create()
    }
  }
</script>