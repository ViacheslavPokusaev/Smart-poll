import Vue from "vue";
import VueRouter from "vue-router";
import AllVotings from "@/views/AllVotings";
import Registration from "@/views/Registration";
import SignIn from "@/views/SignIn";

Vue.use(VueRouter);

export default new VueRouter({
  mode: "history",
  routes: [
    {
      path: "/",
			component: SignIn,
		},
		{
			path: "/signup",
			component: Registration,
		},
    {
      path: "/allvotings",
			component: AllVotings,
			props: true
		},
  ],
});
