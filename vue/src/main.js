import Vue from 'vue'
import App from './App.vue'
Vue.config.productionTip = false

import VueSignalR from './utils/signalR'
Vue.use(VueSignalR, process.env.VUE_APP_BASE_API + 'hub/message')

new Vue({
	render: h => h(App),
}).$mount('#app')
