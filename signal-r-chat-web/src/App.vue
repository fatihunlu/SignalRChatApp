<template>
  <v-app>
    <v-app-bar
      app
      color="primary"
      dark
    >
      <div class="d-flex align-center">
        <v-img
          alt="Vuetify Logo"
          class="shrink mr-2"
          contain
          src="https://cdn.vuetifyjs.com/images/logos/vuetify-logo-dark.png"
          transition="scale-transition"
          width="40"
        />

        <span style="font-weight: bold; font-size: 18px;" >SignalR Chat App</span>
      </div>

      <v-spacer></v-spacer>
    </v-app-bar>

    <v-main>
      <chat-page/>
    </v-main>
  </v-app>
</template>

<script>
import ChatPage from './views/ChatPage';

export default {
  name: 'App',

  components: {
    ChatPage,
  },

  data: () => ({
    //
  }),
};
</script>
