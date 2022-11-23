<template>
    <div v-if="isloadprocess">
        <h1>Loading...</h1>
    </div>
    <div v-if="!isloadprocess">
        <h1>Delete</h1>
        <h3>Are you sure you want to delete this?</h3>
        <div>
            <h4>User</h4>
            <hr />
            <dl class="row">
                <dt class="col-sm-2">Name</dt>
                <dd class="col-sm-10">
                    {{user.name}}
                </dd>
                <dt class="col-sm-2">Age</dt>
                <dd class="col-sm-10">
                    {{user.age}}
                </dd>
                <dt class="col-sm-2">City</dt>
                <dd class="col-sm-10">
                    {{user.city}}
                </dd>
                <dt class="col-sm-2">Email</dt>
                <dd class="col-sm-10">
                    {{user.email}}
                </dd>
            </dl>
            <input type="hidden" v-model="user.id" />
            <input type="button" v-model="buttonname" @click="onclick" :disabled="validate()" class="btn btn-danger" /> |
            <router-link :to="{ name:'Users' }">Back to List</router-link>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';
    export default {
        name: 'Delete',
        data() {
            return {
                user: {},
                buttonname: "Delete",
                isloadprocess: true,
                isdeleteptocess: false
            };
        },
        created() {
            axios.get("http://localhost:14558/api/Users/" + this.$route.params.id).then(response => {
                this.user = response.data;
                this.isloadprocess = false;
            });
        },
        methods: {
            onclick() {
                this.isdeleteprocess = true;
                this.buttonname = "Deleting...";
                axios.delete("http://localhost:14558/api/Users/" + this.$route.params.id).then(() => this.$router.push("/")).catch(console.error());
            },
            validate() {
                return this.isdeleteprocess;
            }
        }
    }
</script>
