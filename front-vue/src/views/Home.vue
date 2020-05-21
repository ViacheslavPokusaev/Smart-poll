<template>
    <Menu :Id="$route.params.Id" />
</template>

<script>
import Menu from "@/components/Menu.vue";

export default {
  components: {
    Menu
  }
};
</script>