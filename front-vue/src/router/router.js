import Vue from "vue";
import VueRouter from "vue-router";
import App from "../App.vue";
import Votings from "../components/ListVotings.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "StartPage",
    component: App,
  },
  {
    path: "/Votings",
    name: "Votings",
    component: Votings,
  },
];

const router = new VueRouter({
  mode: "history",
  options: routes,
});

export default router;
