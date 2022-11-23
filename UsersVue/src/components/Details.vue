<template>
    <div v-if="isloadprocess">
        <h1>Loading...</h1>
    </div>
    <div v-if="!isloadprocess">
        <h1>Details</h1>
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
        </div>
        <div>
            <router-link :to="{ name:'Edit', params: { id: user.id } }">Edit</router-link> |
            <router-link :to="{ name:'Users' }">Back to List</router-link>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';
    export default {
        name: 'Details',
        data() {
            return {
                user: {},
                isloadprocess: true
            };
        },
        created() {
            this.isloadprocess = true;
            axios.get("http://localhost:14558/api/Users/" + this.$route.params.id).then(response => {
                this.user = response.data;
                this.isloadprocess = false;
            });
        }
    }
</script>
