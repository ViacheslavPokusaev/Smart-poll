import Vue from "vue";
import VueRouter from "vue-router";
import AllVotings from "@/views/AllVotings";
import Home from "@/views/Home";

Vue.use(VueRouter);

export default new VueRouter({
  mode: "history",
  routes: [
    {
      path: "/",
      component: Home,
    },
    {
      path: "/allvotings",
      component: AllVotings,
    },
  ],
});
