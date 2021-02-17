<template>
    <v-container>
    <v-row class="text-center">
      <v-col v-if="!isChatStarted" cols="4" offset="4">
          <v-text-field
            v-model="userName"
            hint="you must type your username before begin chat"
            label="User Name"

          ></v-text-field>
          <v-btn
            class="mx-2"
            dark
            color="teal"
            rounded
            :disabled="!userName"
            @click="startChat"
          >
            Start Chat
          </v-btn>
      </v-col>
      <v-col cols="4"></v-col>

      <v-col
        v-if="isChatStarted"
        class="mb-5"
        cols="6"
        offset="3"
        style="padding-top: 3%;"
      >
        <h2 class="headline font-weight-bold mb-3">
          Chats
        </h2>

        <v-row justify="center">
          <v-list three-line min-height="400px" style="max-height: 400px; overflow-y: auto;">
            <template v-for="(item, index) in allMessages" >
              <v-subheader
                v-if="item.header"
                :key="item.header"
                v-text="item.header"
              ></v-subheader>

              <v-divider
                v-else-if="item.divider"
                :key="index"
                :inset="item.inset"
              ></v-divider>

              <v-list-item
                v-else
                :key="item.title"
              >
                <v-list-item-avatar>
                  <v-img :src="item.avatar"></v-img>
                </v-list-item-avatar>

                <v-list-item-content style="min-width: 800px;">
                  <v-list-item-title v-html="item.title" style="text-align: left"></v-list-item-title>
                </v-list-item-content>
              </v-list-item>
            </template> 
          </v-list>
        </v-row>
      </v-col>

      <v-col v-if="isChatStarted" cols="6" offset="3">
          <v-text-field
            v-model="message"
            label="Type message"
            filled
            rounded
            dense
            append-outer-icon="mdi-send"
            @click:append-outer="sendMessage"
          ></v-text-field>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
  export default {
    name: 'ChatPage',

    data: () => ({
      isChatStarted: false,
      userName: '',
      message: '',
      allMessages: [],
      items: [
      ],
    }),

    methods: {
      startChat() {
        const vm = this;

        vm.isChatStarted = true;
      },

      sendMessage() {
        const vm = this;
        vm.$socket.invoke('SendMessage', vm.userName, vm.message)
          .then(response => {
            vm.message = "";
            console.log('message sent:', response);
          });


      }
    },

  sockets: {
      // Equivalent of
      // signalrHubConnection.on('someEvent', (data) => this.someActionWithData(data))

      ReceiveMessage(data) {
        this.allMessages.push({
          avatar: 'https://cdn.vuetifyjs.com/images/lists/3.jpg',
          title: `<span class="text--primary" style="font-weight:bold"> ${data.user}</span>: ${data.message}`
        });
        this.allMessages.push({ divider: true, inset: true });
      }
    }
  }
</script>

<style>

.v-list-item__subtitle {
  -webkit-box-orient: initial !important;
}

</style>