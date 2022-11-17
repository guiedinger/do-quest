import { Button, Container, Toolbar, AppBar as MuiAppBar } from "@mui/material";
import { Logo } from "../Logo";

export const AppBar = () => {
  return (
    <MuiAppBar position="static">
      <Container maxWidth="md">
        <Toolbar>
          <Logo />
          <Button color="inherit">Logout</Button>
        </Toolbar>
      </Container>
    </MuiAppBar>
  );
};
