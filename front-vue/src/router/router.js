import Vue from "vue";
import VueRouter from "vue-router";
import SwithVotings from "@/views/SwithVotings";
import Registration from "@/views/Registration";
import SignIn from "@/views/SignIn";
import Home from "@/views/Home";

Vue.use(VueRouter);

export default new VueRouter({
  mode: "history",
  routes: [
    {
			path: "/",
			name: "SignIn",
			component: SignIn,
		},
		{
			path: "/signup",
			name: "Registration",
			component: Registration,
		},
		{
			path: "/home",
			name: "Home",
			component: Home,
		},
    {
			path: "/activevotings",
			name: "ActiveVotings",
			component: SwithVotings,
			props: true
		},
		,
		{
			path: "/deadlinevotings",
			name: "DeadlineVotings",
			component: SwithVotings,
			props: true
		},
		,
		{
			path: "/privatevotings",
			name: "PrivateVotings",
			component: SwithVotings,
			props: true
		},
		,
		{
			path: "/myvotings",
			name: "MyVotings",
			component: SwithVotings,
			props: true
		},
  ],
});
