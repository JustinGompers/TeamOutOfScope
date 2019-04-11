import Vue from 'vue'
import App from './App.vue'
import VeeValidate from 'vee-validate';

Vue.use(VeeValidate, {
  classes: true,
  classNames: {
    valid: 'is-valid',
    invalid: 'is-invalid'
  }
});
Vue.config.productionTip = false

new Vue({
  render: h => h(App),
}).$mount('#app')
