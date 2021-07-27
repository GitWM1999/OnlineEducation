<template>
    
</template>

<script>

export default ({
    data(){
        return{
            token:''
        }
    },
    created(){
        this.Checktoken();
    },
    methods:{
        Checktoken(){
            alert(1);
            this.token=this.$route.query.token;
            sessionStorage.setItem("token",this.token);
            this.$axios.get("http://10.3.181.32:53590/Login/Checktoken?token="+this.token)
            .then((res)=>{
                if(res.data.code==200){
                     sessionStorage.setItem("UserId",res.data.Id);
                     sessionStorage.setItem("token",res.data.token);

                     this.$router.push('/');
                }
                if(res.data.code==400){
                    sessionStorage.removeItem("token");
                    window.location.href="http://10.3.181.32:53590/Login/Login";
                }
            })
        }
    }
})
</script>
