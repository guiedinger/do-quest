import { Box, Container, Paper } from "@mui/material";
import { AppBar } from "../AppBar";
interface IProps {
  children?: any;
}
export const Template = ({ children }: IProps) => {
  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar />
      <Container maxWidth="md" sx={{ marginTop: "1rem" }}>
        <Paper elevation={2}>{children}</Paper>
      </Container>
    </Box>
  );
};
