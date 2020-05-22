import Vue from "vue";
import VueRouter from "vue-router";
import SignUp from "@/views/SignUp";
import SignIn from "@/views/SignIn";
import Home from "@/views/Home";

import ListPollPublic from "@/components/ListPoll/ListPollPublic";
import ListPollPrivate from "@/components/ListPoll/ListPollPrivate";
import ListPollTakePart from "@/components/ListPoll/ListPollTakePart";
import ListPollDeadLine from "@/components/ListPoll/ListPollDeadLine";
import ListPollPublish from "@/components/ListPoll/ListPollPublish";

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
			name: "SignUp",
			component: SignUp,
		},
		{
			path: "/home",
			name: "Home",
			component: Home,
		},
    {
			path: "/listpollpublic",
			name: "ListPollPublic",
			component: ListPollPublic,
			props: true
		},
		{
			path: "/listpollprivate",
			name: "ListPollPrivate",
			component: ListPollPrivate,
			props: true
		},
		{
			path: "/listpolldeadline",
			name: "ListPollDeadLine",
			component: ListPollDeadLine,
			props: true
		},
		{
			path: "/listpolltakepart",
			name: "ListPollTakePart",
			component: ListPollTakePart,
			props: true
		},
		{
			path: "/listpollpublish",
			name: "ListPollPublish",
			component: ListPollPublish,
			props: true
		},
  ],
});
