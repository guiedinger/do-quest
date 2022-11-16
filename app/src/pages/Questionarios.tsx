import { Box, Button, Paper, Typography } from "@mui/material";
import { Template } from "../components/Template";
interface Questionario {
  descricao: string;
  vigente: boolean;
}
const questionarios: Questionario[] = [
  {
    descricao: "Avaliação do curso",
    vigente: true,
  },
  {
    descricao: "Avaliação da infraestrutura",
    vigente: true,
  },
  {
    descricao: "Avaliação dos docentes",
    vigente: false,
  },
];

export const Questionarios = () => {
  return (
    <Template>
      <Typography
        variant="h6"
        color="primary"
        component="div"
        sx={{ textAlign: "center" }}
      >
        Questionários
      </Typography>
      {questionarios.map((q) => (
        <QuestionarioItem questionario={q} />
      ))}
    </Template>
  );
};

interface IQuestionarioItem {
  questionario: Questionario;
}

const QuestionarioItem = ({ questionario }: IQuestionarioItem) => {
  return (
    <Paper
      sx={{
        padding: "1rem",
        marginTop: "1rem",
        display: "flex",
        flexDirection: "row",
        justifyContent: "space-between",
      }}
    >
      <Typography variant="body1" component="div">
        {questionario.descricao}
      </Typography>
      <Button variant="contained" disabled={!questionario.vigente}>
        Responder
      </Button>
    </Paper>
  );
};
