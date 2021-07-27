<template>
    <div>
        <div class="order-search">
            <select name="" id="numId">
                <option value="订单号">订单号</option>
            </select>
            <input type="text" name="" id="txtContent" placeholder="请输入内容">
            <input type="text" name="" id="txtStart" placeholder="起始时间">
            <input type="text" name="" id="txtEnd" placeholder="截止时间">
            退款状态&emsp;<select name="" id="refund">
                <option value="">未选定</option>
            </select>
            <br><br>
             订单状态 &emsp;<select name="" id="orderSale">
                <option value="">未选定</option>
            </select>
            用户ID&emsp;<input type="text" name="" id="txtId" placeholder="请输入内容">
            商品名称&emsp;<input type="text" name="" id="txtName" placeholder="请输入内容">
            自提点&emsp;<input type="text" name="" id="extract">
            <button id="xuan">选择</button>
            <br><br>
            <button id="search">搜索</button>
            <br><br>
        </div>
        <table class="table table-hover table-bordered table-striped" id="tab">
            <thead>
                <tr>
                    <td>ID</td>
                    <td>商家信息</td>
                    <td>买家信息</td>
                    <td>送货方式</td>
                    <td>支付金额</td>
                    <td>状态</td>
                    <td>操作</td>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in order" :key="item.id">
                    {{order}}
                    <td>{{ item.id }}</td>
                    <td>{{ item.name }}</td>
                    <td>{{ item.buyer }}</td>
                    <td>{{ item.method }}</td>
                    <td>{{ item.money }}</td>
                    <td>
                         <button class="btn btn-default" v-if="item.Sale">未发货</button>
                         <button class="btn btn-warning" v-else>已发货</button>
                    </td>
                    <td>
                         <button class="btn btn-default">发货</button>
                         <button class="btn btn-warning">备注</button>
                    </td>

                </tr>
            </tbody>
        </table>
    <nav>
        <ul class="pagination">
            <li>
            <a href="#" aria-label="Previous">
                <span aria-hidden="true">&laquo;</span>
            </a>
            </li>
            <li><a href="#">1</a></li>
            <li><a href="#">2</a></li>
            <li><a href="#">3</a></li>
            <li><a href="#">4</a></li>
            <li><a href="#">5</a></li>
            <li>
            <a href="#" aria-label="Next">
                <span aria-hidden="true">&raquo;</span>
            </a>
            </li>
        </ul>
    </nav>
    </div>
</template>
<script>
export default {
    name:"OrderManagement",
    data(){
     return {
         order:[
             {id:1,name:"服装",buyer:"昵称：曲尘",method:"自提",money:"288.00",Sale:true},
             {id:2,name:"服装",buyer:"昵称：曲尘",method:"自提",money:"288.00",Sale:false},
             {id:3,name:"服装",buyer:"昵称：曲尘",method:"自提",money:"288.00",Sale:true}
         ]
     };
    },
    created(){
        console.log(this.order)
    }

}
</script>

<style scoped>
.order-search{
    margin-left:30px;
}
#numId{
    width:120px;
    height:20px;
}
#refund{

    width:120px;
    height:20px;
}
#orderSale{

    width:120px;
    height:20px;
}
  #extract{
      width:115px;
      height: 23px;
      border: 1px solid gray;
  }
  #xuan{
    width:50px;
    height: 27px;
    background-color:gainsboro;
    border: 1px solid gainsboro;

  }
  #search{
    width:60px;
    height: 35px;
    border: 0 none;
    background-color:dodgerblue;
    color:white;

  }
  #tab{
      width:1000px;
      margin-left: 30px;
  }
  table thead{
      text-align:center;
  }
  table tbody{
      text-align:center;

  }
  .pagination{
      float:right;
      margin-right:500px;
  }
</style>