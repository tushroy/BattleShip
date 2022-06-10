<template>
    <div class="post">
        <div v-if="loading" class="loading">
            Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
        </div>
        <div v-if="battleShipData.isGameEnd" style="text-align:left">
            <button @click="resetGame()">Reset Game</button>
        </div>
        <div style="text-align:left">
            Message: {{battleShipData.message}}
        </div>
        <div v-if="battleShipData" class="content">
            <table>
                <tbody>
                    <tr v-for="(rowData,i) in battleShipData.boardData" :key="i">
                        <td v-for="(col,j) in rowData" :key="j">
                            <button @click="shootMissile(i,j)">
                                <div v-if="col === 'S'">.</div>
                                <div v-else>{{col}}</div>
                            </button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script lang="js">
    import Vue from 'vue';

    export default Vue.extend({
        data() {
            return {
                loading: false,
                battleShipData: null
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchData() {
                this.battleShipData = null;
                this.loading = true;

                fetch('api/battleship')
                    .then(r => r.json())
                    .then(json => {
                        this.battleShipData = json;
                        this.loading = false;
                        return;
                    });
            },
            shootMissile(row, col) {
                fetch('api/battleship/' + row + '/' + col)
                    .then(r => r.json())
                    .then(json => {
                        this.battleShipData = json;
                        return;
                    });
            },
            resetGame() {
                fetch('api/battleship/reset')
                    .then(r => r.json())
                    .then(json => {
                        this.battleShipData = json;
                        return;
                    });
            }
        },
    });
</script>