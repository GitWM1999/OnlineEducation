// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import '../static/bootstrap/css/bootstrap.css'
import axios  from 'axios'
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';



import VueQuillEditor from 'vue-quill-editor';
import 'quill/dist/quill.core.css'
import 'quill/dist/quill.snow.css'
import 'quill/dist/quill.bubble.css'
Vue.use (axios);
Vue.prototype.$http = axios;
Vue.config.productionTip = false;
Vue.use(ElementUI);
Vue.use(VueQuillEditor);
Vue.prototype.bus=new Vue();
/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>'
})
