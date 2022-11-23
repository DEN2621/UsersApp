<template>
    <router-view>
        <h1>Edit</h1>
        <h4>User</h4>
        <hr />
        <div class="row">
            <div class="col-md-4">
                <input type="hidden" v-model="user.id" />
                <div class="form-group">
                    <label class="control-label">Name</label>
                    <input v-model="user.name" class="form-control" />
                </div>
                <div class="form-group">
                    <label class="control-label">Age</label>
                    <input v-model="user.age" class="form-control" />
                </div>
                <div class="form-group">
                    <label class="control-label">City</label>
                    <input v-model="user.city" class="form-control" />
                </div>
                <div class="form-group">
                    <label class="control-label">Email</label>
                    <input v-model="user.email" class="form-control" />
                </div>
                <div class="form-group">
                    <input type="button" value="Save" @click="onclick" :disabled="validate()" class="btn btn-primary" />
                </div>
            </div>
        </div>
        <div>
            <router-link :to="{ name:'Users' }">Back to List</router-link>
        </div>
    </router-view>
</template>

<script>
    import axios from 'axios';
    export default {
        name: 'Edit',
        data() {
            return {
                user: {
                    name: "",
                    age: 0,
                    city: "",
                    email: ""
                },
            };
        },
        created() {
            axios.get("http://localhost:14558/api/Users/" + this.$route.params.id).then(response => this.user = response.data);
        },
        methods: {
            onclick() {
                axios.put("http://localhost:14558/api/Users/" + this.$route.params.id, this.user, { withCredentials: false }).then(() => this.$router.push("/")).catch(function (error) { console.log(error); });
            },
            validate() {
                return this.user.name === "" || this.user.age === null || this.user.city === "" || this.user.email === "";
            }
        }
    }
</script>
