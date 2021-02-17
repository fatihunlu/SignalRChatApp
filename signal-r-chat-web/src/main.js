import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify';

Vue.config.productionTip = false

import VueSignalR from '@latelier/vue-signalr'
 
Vue.use(VueSignalR, 'https://localhost:44381/chathub');

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App),
  created() {
    this.$socket.start({
      log: false // Active only in development for debugging.
    });
  }
}).$mount('#app')
