
class indicatorManager(object):
    delta = []
    seta = []
    alpha = []
    SMR = []
    midBeta = []
    highBeta = []

    beta = []

    ##초기값: -100
    delta_total_power = 0#-100
    seta_total_power = 0#-100
    alpha_total_power = 0#-100
    SMR_total_power = 0#-100
    midBeta_total_power = 0#-100
    highBeta_total_power = 0#-100

    beta_total_power = 0#-100

    total_power = 0  # -100

    #self.gamma_total_power = -100

    def setData(self, signalPower):
        self.delta_total_power = 0
        self.seta_total_power = 0
        self.alpha_total_power = 0
        self.SMR_total_power = 0
        self.midBeta_total_power = 0
        self.highBeta_total_power = 0

        self.beta_total_power = 0

        #self.gamma_total_power = 0

        #본 코드
        #self.delta = signalPower[0:8]
        #self.seta = signalPower[8:16]
        #self.alpha = signalPower[16:26]
        #self.SMR = signalPower[26:32]
        #self.midBeta = signalPower[30:36]
        #self.highBeta = signalPower[36:60]
        #self.gamma = signalPower[61:100]


        # test 코드
        self.delta = signalPower[0:8]
        self.seta = signalPower[8:16]
        self.alpha = signalPower[16:26]
        self.SMR = signalPower[26:32]
        self.midBeta = signalPower[30:36]
        self.highBeta = signalPower[36:60]

        self.beta = signalPower[26:36]

        for power in self.delta:
            self.delta_total_power += power
        for power in self.seta:
            self.seta_total_power += power
        for power in self.alpha:
            self.alpha_total_power += power
        for power in self.SMR:
            self.SMR_total_power += power
        for power in self.midBeta:
            self.midBeta_total_power += power
        for power in self.highBeta:
            self.highBeta_total_power += power

        for power in self.beta:
            self.beta_total_power += power

        total_power = self.delta_total_power + self.seta_total_power +  self.alpha_total_power +self.SMR_total_power + self.midBeta_total_power
        #print(signalPower)
        #print('seta',self.seta_total_power)
        #print('SMR',self.SMR_total_power)
        #print('midbeta',self.midBeta_total_power)

        self.delta_total_power /= 9 #17
        self.seta_total_power /= 9  #17
        self.alpha_total_power /= 11  #21
        self.SMR_total_power /= 7  #13
        self.midBeta_total_power /= 7  #13
        self.highBeta_total_power /= 25  #49

        self.beta_total_power /= 11

    #집중도지표 = SMR + Mid베타 (beta_total_power) / 쎄타
    def concentration(self):      
        return  self.beta_total_power / ( self.seta_total_power + self.beta_total_power )

    #명상도지표 = 알파 / High베타
    def meditation(self):
        return self.alpha_total_power / ( self.highBeta_total_power + self.alpha_total_power)

