<template>
  <div id="app">
  	<!--<GetData v-bind:info="items"/>-->
		<input type="text" id="myid">
		<button v-on:click="greet">OK</button>
		<!--<Test/>-->
    <router-view/>
  </div>
</template>

<script>
import axios from 'axios';
//import GetData from '@/components/GetData';

export default {
	name: 'app',
	data(){
    return {
			users: [],
			name: 'dsdsdsd'
    };
	},
	methods: {
    greet: function () {
			let _users;
			axios.get('http://localhost:5001/user').then(response => (this._users = response.data));
			this.users = _users;
			console.log(this.users);
      }
    },
	components:{
		//GetData
	}	
}
</script>

<style>
	@import 'components/reboot.css';
	#app{
		display: flex;
		flex-wrap: wrap;
		justify-content: space-around;
		background-color: aqua;
	}
	div{
		flex: 200px;
		margin: 5px 5px 5px 5px;
		background-color: red;
	}
</style>
