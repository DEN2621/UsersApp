<template>
    <div v-if="isloadprocess">
        <h1>Loading...</h1>
    </div>
    <div v-if="!isloadprocess">
        <h1>Users</h1>
        <p>
            <router-link to="Create">Create New</router-link>
        </p>
        <table class="table">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Age</th>
                    <th>City</th>
                    <th>Email</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="user in users">
                    <td>
                        {{user.name}}
                    </td>
                    <td>
                        {{user.age}}
                    </td>
                    <td>
                        {{user.city}}
                    </td>
                    <td>
                        {{user.email}}
                    </td>
                    <td>
                        <router-link :to="{ name:'Edit', params: { id: user.id } }">Edit</router-link> |
                        <router-link :to="{ name:'Details', params: { id: user.id } }">Details</router-link> |
                        <router-link :to="{ name:'Delete', params: { id: user.id } }">Delete</router-link>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import axios from 'axios';
    export default {
        name: 'Users',
        data() {
            return {
                users: null,
                isloadprocess: true
            };
        },
        created() {
            axios.get("http://localhost:14558/api/Users/").then(response => {
                this.users = response.data;
                this.isloadprocess = false;
            });
        }
    }
</script>
