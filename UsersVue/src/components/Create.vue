<template>
    <h1>Create</h1>
    <h4>User</h4>
    <hr />
    <div class="row">
        <div class="col-md-4">
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
                <input type="button" v-model="buttonname" @click="onclick" :disabled="validate()" class="btn btn-primary" />
            </div>
        </div>
    </div>
    <div>
        <router-link :to="{ name:'Users' }">Back to List</router-link>
    </div>
</template>

<script>
    import axios from 'axios';
    export default {
        name: 'Create',
        data() {
            return {
                user: {
                    name: "",
                    age: "",
                    city: "",
                    email: ""
                },
                buttonname: "Create",
                iscreateprocess: false
            };
        },
        methods: {
            onclick() {
                this.iscreateprocess = true;
                this.buttonname = "Creating...";
                axios.post("http://localhost:14558/api/Users/", this.user, { withCredentials: false }).then(() => this.$router.push("/")).catch(function (error) { console.log(error); });
            },
            validate() {
                return this.iscreateprocess || this.user.name === "" || this.user.age === "" || this.user.city === "" || this.user.email === "";
            }
        }
    }
</script>
