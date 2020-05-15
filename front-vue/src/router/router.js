import Vue from "vue";
import VueRouter from "vue-router";
import AllVotings from "@/views/AllVotings.vue";
import Home from "@/views/Home.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    component: Home,
  },
  {
    path: "/AllVotings",
    component: AllVotings,
  },
];

const router = new VueRouter({
  mode: "history",
  routes,
});

export default router;
