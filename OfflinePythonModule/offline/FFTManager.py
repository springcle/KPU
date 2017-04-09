import matplotlib.pyplot as plt
import numpy as np
import plotly.plotly as py
from pylab import *
from numpy.fft import fft, fftshift
from FFTManager import np

class FFTManager(object):

    def fftTransform(self, data, timeCount):
        
            ## Perform FFT WITH SCIPY
            signalFFT = np.fft.fft(data)
        
            ## Get Power Spectral Density
            signalPSD = np.abs(signalFFT) **2

            ## Get frequencies corresponding to signal PSD
            fftFreq = np.fft.fftfreq(len(data),1/250) ##두번째 인자는 sampling rate(Fs)의 역수

            ## Get positive half of frequencies
            i = fftFreq>0

            ##각 주파수의 세기
            signalPower = 10*np.log10(signalPSD[i]) 

            ##
            #plt.figure(timeCount)
            #plt.figurefigsize=(8,4);
            #plt.scatter(fftFreq[i], signalPower); #산점도 그래프
            #plt.plot(fftFreq[i], signalPower); #선 그래프
            #plt.xlabel('Frequency Hz');
            #plt.ylabel('PSD (dB)')

            #plt.grid()
            #plt.show()
            return signalPower


            
 

