import Layout,{Header} from "antd/es/layout/layout";
import "./globals.css";
import { Menu } from "antd";
import { Content } from "antd/es/layout/layout";
import Link from "next/link";

const items = [
  {key: "home", label:<link href={"/"}>Home</link>},
  {key: "books", label:<link href={"/books"}>Books</link>},
];

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body> 
        <Layout style ={{ minHeight: "100vh" }}>
           <Header> 
            <Menu 
            theme="dark" 
            mode="horizontal"
            items={items}
            style={{flex:1,minWidth:0}}
            />
            </Header>
         
        <Content style={{padding: "0 48px"}}>{children} </Content>
        <footer style={{textAlign:"center"}}>
          Book store 2025 Create by Alex
        </footer>
        </Layout>
        </body>
    </html>
  );
}
