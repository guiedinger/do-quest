import { Box, Container } from "@mui/material";
import { AppBar } from "../AppBar";
interface IProps {
  children?: any;
}
export const Template = ({ children }: IProps) => {
  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar />
      <Container maxWidth="sm" sx={{ marginTop: "1rem" }}>
        {children}
      </Container>
    </Box>
  );
};
