import Vue from 'vue'
import App from './App.vue'
import VeeValidate from 'vee-validate';
import VModal from 'vue-js-modal';
import VueFlip from 'vue-flip';

Vue.use(VeeValidate, {
  classes: true,
  classNames: {
    valid: 'is-valid',
    invalid: 'is-invalid'
  }
});
Vue.use(VModal);
Vue.config.productionTip = false
Vue.use(VueFlip);

new Vue({
  render: h => h(App),
}).$mount('#app')
