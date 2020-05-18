<template>
  <div>
    <Menu :UserID="$route.params.UserID" />
		{{$route.params}}
		Тут будет контент
  </div>
</template>

<script>
import Menu from "@/components/Menu.vue";

export default {
  components: {
    Menu
  }
};
</script>