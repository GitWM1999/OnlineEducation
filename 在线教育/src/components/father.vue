<template>
    <div>
    <div>我是父组件</div>
    <div>我发送给第一个组件的信息是:{{msg}}</div>

    <div>我即将接收第二组件传值是:{{child2Msg}}</div>
    <br/>
    <br/>
    <br/>
    <div>
        <div id="child1">
            <childone :msg="msg"/>
        </div>
    </div>
    <br/>
    <br/>
    <br/>
    <div>
        <div id="child2">
            <childtwo @toParent="getMag"/>
        </div>
    </div>
    </div>
</template>
<script>
import childone from "../components/childone.vue";
import childtwo from "../components/childtwo.vue";

export default{
    components:{
        childone,
        childtwo
    },
    data(){
        return{
         msg:"我是父组件，我给你发消息",
         child2Msg:""
        };
    },
    methods:{
        getMag(msg){
            this.child2Msg=msg;
        }
    }
}
</script>
