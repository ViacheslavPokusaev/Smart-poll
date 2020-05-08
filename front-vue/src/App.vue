<template>
  <div id="app">
		<div>Lorem ipsum dolor sit amet consectetur adipisicing elit. Tempora quis beatae nulla hic earum ut doloremque quas ad dolorum sequi! Necessitatibus fugit fugiat porro asperiores voluptatem laboriosam nulla sint qui?</div>
		<div>Lorem ipsum dolor sit amet consectetur adipisicing elit. Totam dignissimos cumque quia quos error modi facilis obcaecati deserunt dolores dicta, iure expedita velit inventore vel ipsa mollitia, numquam suscipit rerum.</div>
		<div>Hello world</div>
		<div>ffefefef</div>
    <router-view/>
  </div>
</template>

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
