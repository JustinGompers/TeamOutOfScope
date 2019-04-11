import Vue from 'vue'
import App from './App.vue'
import VeeValidate from 'vee-validate';
import VModal from 'vue-js-modal';

Vue.use(VeeValidate, {
  classes: true,
  classNames: {
    valid: 'is-valid',
    invalid: 'is-invalid'
  }
});
Vue.use(VModal);
Vue.config.productionTip = false

new Vue({
  render: h => h(App),
}).$mount('#app')
